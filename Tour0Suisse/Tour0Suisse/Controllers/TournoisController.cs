using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tour0Suisse.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Tour0Suisse.Controllers;

namespace Tour0Suisse.Web.Controllers
{
    public class TournoisController : Controller
    {
        // GET: Tournois
        public async Task<IActionResult> Index()
        {
            List<ViewTournament> ListTournois;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44321/View/GetTournaments"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ListTournois = JsonConvert.DeserializeObject<IEnumerable<ViewTournament>>(apiResponse).ToList();
                }
            }

            return View("~/Views/Tournoi/Index.cshtml", ListTournois);
        }

        // GET: Tournois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournoi tournoi;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44321/View/GetTournament?id=" + id.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tournoi = JsonConvert.DeserializeObject<Tournoi>(apiResponse);
                }
            }

            if (tournoi == null || tournoi.IdTournament <1)
            {
                return NotFound();
            }

            return View("~/Views/Tournoi/Details.cshtml", tournoi);
        }


        public async Task<IActionResult> Create()
        {

            IEnumerable<ViewJeu> Jeus = new List<ViewJeu>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44321/View/GetJeus"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Jeus = JsonConvert.DeserializeObject<IEnumerable<ViewJeu>>(apiResponse);
                }
            }

            ViewData["AllGame"] = new SelectList(Jeus, "IdGame", "Name");
            return View("~/Views/Tournoi/CreateTournoi.cshtml");
        }

        // POST: Tournois/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTournament,Name,Date,Description,IdGame,MaxNumberPlayer,DeckListNumber,Ppwin,Ppdraw,Pplose,Over,Deleted")] Tournoi tournoi)
        {
            if (ModelState.IsValid)
            {
                if ((tournoi.Organisateurs == null || tournoi.Organisateurs.Count() == 0) && int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
                {
                    tournoi.Organisateurs = new List<ViewOrga>{new ViewOrga{Level = 0, IdUser = IdUser, IdTournament = -1, Name = "", Pseudo = ""}};
                }

                if (tournoi.Organisateurs != null && tournoi.Organisateurs.Count() != 0)
                {

                    using (var httpClient = new HttpClient())
                    {
                        using (var response =
                            await httpClient.PostAsJsonAsync("https://localhost:44321/Procedure/CreateTournoi",
                                tournoi))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            if (JsonConvert.DeserializeObject<bool>(apiResponse))
                            {
                                return RedirectToAction(nameof(Index));
                            }
                        }
                    }
                }
            }



            IEnumerable<ViewJeu> Jeus = new List<ViewJeu>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44321/View/GetJeus"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Jeus = JsonConvert.DeserializeObject<IEnumerable<ViewJeu>>(apiResponse);
                }
            }

            ViewData["AllGame"] = new SelectList(Jeus, "IdGame", "Name", tournoi.jeu.IdGame);
            return View("~/Views/Tournoi/CreateTournoi.cshtml", tournoi);
        }



        // GET: Tournois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournoi tournoi;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44321/View/GetTournament?id=" + id.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tournoi = JsonConvert.DeserializeObject<Tournoi>(apiResponse);
                }
            }

            if (tournoi == null || tournoi.IdTournament < 1)
            {
                return NotFound();
            }
            IEnumerable<ViewJeu> Jeus;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44321/View/GetJeus"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Jeus = JsonConvert.DeserializeObject<IEnumerable<ViewJeu>>(apiResponse);
                }
            }

            ViewData["AllGame"] = new SelectList(Jeus, "IdGame", "Name", tournoi.jeu.IdGame);
            return View("~/Views/Tournoi/Edit.cshtml", tournoi);
        }

        // POST: Tournois/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTournament,Name,Date,Description,IdGame,MaxNumberPlayer,DeckListNumber,Ppwin,Ppdraw,Pplose,Over,Deleted")] Tournoi tournoi)
        {
            if (id != tournoi.IdTournament)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                using (var httpClient = new HttpClient())
                {
                    using (var response =
                        await httpClient.PostAsJsonAsync("https://localhost:44321/Procedure/EditTournoi",
                            tournoi))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (JsonConvert.DeserializeObject<bool>(apiResponse))
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            }
            IEnumerable<ViewJeu> Jeus;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44321/View/GetJeus"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Jeus = JsonConvert.DeserializeObject<IEnumerable<ViewJeu>>(apiResponse);
                }
            }

            ViewData["AllGame"] = new SelectList(Jeus, "IdGame", "Name", tournoi.jeu.IdGame);
            return View("~/Views/Tournoi/Edit.cshtml", tournoi);
        }

        // GET: Tournois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournoi tournoi;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44321/View/GetTournament?id=" + id.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tournoi = JsonConvert.DeserializeObject<Tournoi>(apiResponse);
                }
            }

            if (tournoi == null || tournoi.IdTournament < 1)
            {
                return NotFound();
            }

            return View("~/Views/Tournoi/Delete.cshtml", tournoi);
        }

        // POST: Tournois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response =
                    await httpClient.PostAsJsonAsync("https://localhost:44321/Procedure/DeleteTournoi",
                        id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (JsonConvert.DeserializeObject<bool>(apiResponse))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }

            return RedirectToAction(nameof(Delete), id);
        }
    }
}