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
using Tour0Suisse.Web.Procedure;

namespace Tour0Suisse.Web.Controllers
{
    public class TournoisController : Controller
    {
        // GET: Tournois
        public async Task<IActionResult> Index()
        {
            List<ViewTournament> listTournois = (await CallAPI.GetAllTournaments()).ToList();

            return View("~/Views/Tournoi/Index.cshtml", listTournois);
        }

        // GET: Tournois/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Tournoi tournoi = await CallAPI.GetTournoiById(id);

            if (tournoi == null || tournoi.IdTournament < 1)
            {
                return NotFound();
            }

            return View("~/Views/Tournoi/Details.cshtml", tournoi);
        }


        public async Task<IActionResult> Create()
        {
            var Jeus = await CallAPI.GetAllJeus();

            ViewData["AllGame"] = new SelectList(Jeus, "IdGame", "Name");
            return View("~/Views/Tournoi/CreateTournoi.cshtml");
        }

        // POST: Tournois/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTournament,Name,Date,Description,IdGame,MaxNumberPlayer,DeckListNumber,Ppwin,Ppdraw,Pplose,Over,Deleted")]
            Tournoi tournoi)
        {
            if (ModelState.IsValid)
            {
                if ((tournoi.Organisateurs == null || !tournoi.Organisateurs.Any()) && int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
                {
                    tournoi.Organisateurs = new List<ViewOrga> {new ViewOrga {Level = 0, IdUser = IdUser, IdTournament = -1, Name = "", Pseudo = ""}};
                }

                if (tournoi.Organisateurs != null && tournoi.Organisateurs.Count() != 0)
                {
                    var retourApi = await CallAPI.InsertTournoi(tournoi);
                    if (retourApi.Succes)
                    {
                        return RedirectToAction("Details", new {id = retourApi.CreateID});
                    }
                }
            }


            IEnumerable<ViewJeu> Jeus = await CallAPI.GetAllJeus();

            ViewData["AllGame"] = new SelectList(Jeus, "IdGame", "Name", tournoi.jeu.IdGame);
            return View("~/Views/Tournoi/CreateTournoi.cshtml", tournoi);
        }


        // GET: Tournois/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Tournoi tournoi = await CallAPI.GetTournoiById(id);

            if (tournoi == null || tournoi.IdTournament < 1)
            {
                return NotFound();
            }

            IEnumerable<ViewJeu> Jeus = await CallAPI.GetAllJeus();

            ViewData["AllGame"] = new SelectList(Jeus, "IdGame", "Name", tournoi.jeu.IdGame);
            return View("~/Views/Tournoi/Edit.cshtml", tournoi);
        }

        // POST: Tournois/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTournament,Name,Date,Description,IdGame,MaxNumberPlayer,DeckListNumber,Ppwin,Ppdraw,Pplose,Over,Deleted")]
            Tournoi tournoi)
        {
            if (id != tournoi.IdTournament)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                RetourAPI retourApi = await CallAPI.UpdateTournoi(tournoi);
                if (retourApi.Succes)
                {
                    return RedirectToAction("Details", new {id = tournoi.IdTournament});
                }
            }

            IEnumerable<ViewJeu> Jeus = await CallAPI.GetAllJeus();

            ViewData["AllGame"] = new SelectList(Jeus, "IdGame", "Name", tournoi.jeu.IdGame);
            return View("~/Views/Tournoi/Edit.cshtml", tournoi);
        }

        // GET: Tournois/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Tournoi tournoi = await CallAPI.GetTournoiById(id);

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
                RetourAPI retourApi = await CallAPI.DeleteTournoi(id);
                if (retourApi.Succes)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Delete), id);
            }
        }

        public async Task<IActionResult> Register(int? id)
        {
            if (id == null || !int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
            {
                return NotFound();
            }

            Tournoi tournoi = await CallAPI.GetTournoiById((int)id);

            if (tournoi == null || tournoi.IdTournament < 1)
            {
                return NotFound();
            }

            ViewBag.NbDeck = tournoi.DeckListNumber;
            ViewData["Title"] = "S'inscire pour " + tournoi.Name;
            return View("~/Views/Tournoi/Register.cshtml", new Joueur {IdTournament = (int) id});
        }

        // POST: Decks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Deck, IdTournament")] Joueur joueur)
        {
            if (joueur.IdTournament < 1 || !int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                joueur.User.IdUser = IdUser;


                RetourAPI retourApi = await CallAPI.RegisterTournoi(joueur);
                if (retourApi.Succes)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            Tournoi tournoi = await CallAPI.GetTournoiById(joueur.IdTournament);

            if (tournoi == null || tournoi.IdTournament < 1)
            {
                return NotFound();
            }

            ViewBag.NbDeck = tournoi.DeckListNumber;
            ViewData["Title"] = "S'inscire pour " + tournoi.Name;
            return View("~/Views/Tournoi/Register.cshtml", joueur);
        }
    }
}