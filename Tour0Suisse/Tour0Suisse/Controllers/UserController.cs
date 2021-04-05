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
using Tour0Suisse.Web.Procedure;

namespace Tour0Suisse.Controllers
{

    public class UserController : Controller
    {


        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Utilisateurs
        public async Task<IActionResult> AllUser()
        {
            IEnumerable<ViewUser> users;

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
            if (user != null && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.HexaPassword))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync("https://localhost:44321/Procedure/LogIN", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewUser Logged = JsonConvert.DeserializeObject<ViewUser>(apiResponse);
                        if (Logged.IdUser >0 && Logged.Pseudo!= null)
                        {
                            HttpContext.Session.SetString("UserId", Logged.IdUser.ToString());
                            HttpContext.Session.SetString("User", Logged.Pseudo);
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

            Utilisateur user = await CallAPI.GetUser(id);

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
        public async Task<IActionResult> Create([Bind("IdUser,Pseudo,Email,Password,Organizer,Deleted")] Utilisateur Utilisateur)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync("https://localhost:44321/Procedure/CreateUser", Utilisateur))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        RetourAPI retourApi = JsonConvert.DeserializeObject<RetourAPI>(apiResponse);
                        if (retourApi.Succes)
                        {
                            return View("~/Views/User/InscriptionReussie.cshtml");
                        }
                    }
                }

            }
            return View("~/Views/User/Inscription.cshtml", Utilisateur);
        }


        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
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
                        RetourAPI retourApi = JsonConvert.DeserializeObject<RetourAPI>(apiResponse);
                        if (retourApi.Succes)
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
                    RetourAPI retourApi = JsonConvert.DeserializeObject<RetourAPI>(apiResponse);
                    if (retourApi.Succes)
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

        public async Task<IActionResult> AddGamePseudo(int id)
        {
            if (!int.TryParse(HttpContext.Session.GetString("UserId"), out int SessionId) || SessionId != id)
            {
                return NotFound();
            }

            var utilisateur = await CallAPI.GetUser(id);

            var Jeus = await CallAPI.GetAllJeus();
            if (Jeus != null)
                foreach (ViewJeu jeu in Jeus)
                {
                    if (!utilisateur.PseudoIgs.Any(j => j.IdGame == jeu.IdGame))
                    {
                        utilisateur.PseudoIgs.Add(new ViewPseudo { Game = jeu.Name, IdGame = jeu.IdGame, IdUser = utilisateur.IdUser, IgPseudo = "" });
                    }
                }

            return View("~/Views/User/AddGamePseudo.cshtml", utilisateur);
        }

        [HttpPost, ActionName("AddGamePseudo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGamePseudoSend([Bind("IdUser, PseudoIgs")] Utilisateur utilisateur)
        {
            if (!int.TryParse(HttpContext.Session.GetString("UserId"), out int SessionId) || SessionId != utilisateur.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync("https://localhost:44321/Procedure/UpdateUserIgPseudo", utilisateur))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        RetourAPI retourApi = JsonConvert.DeserializeObject<RetourAPI>(apiResponse);
                        if (retourApi.Succes)
                        {
                            return RedirectToAction("Details", new{id = utilisateur.IdUser});
                        }
                    }
                }
            }

            return View("~/Views/User/AddGamePseudo.cshtml", utilisateur);
        }
    }
}