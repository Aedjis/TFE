using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tour0Suisse.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;

namespace Tour0Suisse.Controllers
{

    public class UserController : Controller
    {


        public async Task<IActionResult> Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Utilisateurs
        public async Task<IActionResult> AllUser()
        {
            IEnumerable<ViewUser> users = new List<ViewUser>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44321/View/GetUsers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<IEnumerable<ViewUser>>(apiResponse);
                }
            }
            
            return View( users);
        }

        public ActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return View("~/Views/Home/Index.cshtml");
        }


        public async Task<ActionResult> LogIn(Utilisateur user = null)
        {
            ViewUser Logged;
            if (user != null && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.HexaPassword))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync("https://localhost:44321/Procedure/LogIN", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Logged = JsonConvert.DeserializeObject<ViewUser>(apiResponse);
                        if (Logged.IdUser >0 && Logged.Pseudo!= null)
                        {
                            HttpContext.Session.SetString("UserId", Logged.IdUser.ToString());
                            HttpContext.Session.SetString("User", Logged.Pseudo.ToString());
                            return View("~/Views/Home/Index.cshtml");
                        }
                    }
                }
            }
           
            return View("~/Views/User/Connexion.cshtml", user);
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Utilisateur user = new Utilisateur();

            using (var httpClient = new HttpClient())
            {
                string requestUri = "https://localhost:44321" + "/View" + "/GetUser" + "?id=" + id.ToString();
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<Utilisateur>(apiResponse);
                }
            }

            if(user == null || user.IdUser <1)
            {
                return NotFound();
            }

            return View("~/Views/User/Profil.cshtml", user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View("~/Views/User/Inscription.cshtml");
        }

        // POST: Utilisateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,Pseudo,Email,Password,Organizer,Deleted")] Utilisateur User)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync("https://localhost:44321/Procedure/CreateUser", User))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (JsonConvert.DeserializeObject<bool>(apiResponse))
                        {
                            return View("~/Views/User/InscriptionReussie.cshtml");
                        }
                    }
                }

            }
            return View("~/Views/User/Inscription.cshtml", User);
        }


        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Utilisateur utilisateur;

            using (var httpClient = new HttpClient())
            {
                string requestUri = "https://localhost:44321" + "/View" + "/GetUser" + "?id=" + id.ToString();
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    utilisateur = JsonConvert.DeserializeObject<Utilisateur>(apiResponse);
                }
            }

            if (utilisateur == null)
            {
                return NotFound();
            }
            return View("~/Views/User/UpdateProfil.cshtml", utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,Pseudo,Email,Password,Organizer,Deleted")] Utilisateur utilisateur)
        {
            if (!int.TryParse(HttpContext.Session.GetString("UserId"), out int SessionId) || id != utilisateur.IdUser || SessionId != utilisateur.IdUser)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync("https://localhost:44321/Procedure/EditUser", utilisateur))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (JsonConvert.DeserializeObject<bool>(apiResponse))
                        {
                            return RedirectToAction("Details", new {id = utilisateur.IdUser});
                        }
                    }
                }
            }

            return View("~/Views/User/UpdateProfil.cshtml", utilisateur);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View("~/Views/User/DeletedCompte.cshtml", new Utilisateur{IdUser= id});
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([Bind("IdUser,Password")] Utilisateur utilisateur)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("https://localhost:44321/Procedure/DeleteUser", utilisateur))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (!JsonConvert.DeserializeObject<bool>(apiResponse))
                    {
                        return RedirectToAction("Delete", new { id = utilisateur.IdUser });
                    }
                    else
                    {
                        HttpContext.Session.Clear();
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateurExists(int id)
        {
            return false;//_context.Utilisateur.Any(e => e.IdUser == id);
        }

        //public async Task<IActionResult> AddGamePseudo(Utilisateur utilisateur)
        //{
        //    if (!int.TryParse(HttpContext.Session.GetString("UserID"), out int SessionId) || SessionId != utilisateur.IdUser)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            using (var response = await httpClient.PostAsJsonAsync("https://localhost:44321/Procedure/AddPseudo", ))
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                if (JsonConvert.DeserializeObject<bool>(apiResponse))
        //                {
        //                    return RedirectToAction("Details", utilisateur.IdUser);
        //                }
        //            }
        //        }
        //    }

        //    return View("~/Views/User/AddGamePseudo.cshtml", utilisateur);
        //}
    }
}