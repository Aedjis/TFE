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
            ViewData["Title"] = "Liste des tournois";
            return View("~/Views/Tournoi/Index.cshtml", listTournois);
        }

        // GET: Tournois/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if(id < 1)
            {
                return NotFound();
            }
            Tournoi tournoi = await CallAPI.GetTournoiById(id);

            if (tournoi == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Détails du tournoi";
            return View("~/Views/Tournoi/Details.cshtml", tournoi);
        }


        public async Task<IActionResult> Create()
        {
            if (!int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
            {
                return RedirectToAction("Index");
            }
            var Jeus = await CallAPI.GetAllJeus();

            ViewData["AllGame"] = new SelectList(Jeus, "IdGame", "Name");
            ViewData["Title"] = "Création d'un tournoi";
            return View("~/Views/Tournoi/CreateTournoi.cshtml");
        }

        // POST: Tournois/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTournament,Name,Date,Description,IdGame,MaxNumberPlayer,DeckListNumber,Ppwin,Ppdraw,Pplose,Over,Deleted,Dotation")]
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
            ViewData["Title"] = "Création d'un tournoi";
            return View("~/Views/Tournoi/CreateTournoi.cshtml", tournoi);
        }


        // GET: Tournois/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var temp = await CallAPI.GetTournoi(id);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;

            IEnumerable<ViewJeu> Jeus = await CallAPI.GetAllJeus();

            ViewData["AllGame"] = new SelectList(Jeus, "IdGame", "Name", tournoi.jeu.IdGame);
            ViewData["Title"] = "Modifier un tournoi";
            return View("~/Views/Tournoi/Edit.cshtml", tournoi);
        }

        // POST: Tournois/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTournament,Name,Date,Description,IdGame,MaxNumberPlayer,DeckListNumber,Ppwin,Ppdraw,Pplose,Over,Deleted,Dotation")]
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
            ViewData["Title"] = "Modifier un tournoi";
            return View("~/Views/Tournoi/Edit.cshtml", tournoi);
        }

        // GET: Tournois/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var temp = await CallAPI.GetTournoi(id);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;

            ViewData["Title"] = "Supprimer un tournoi";
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

        public async Task<IActionResult> Register(int id)
        {
            if (!int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
            {
                return NotFound();
            }

            var temp = await CallAPI.GetTournoi(id);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;

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
                    return RedirectToAction("Details", "Tournois", new{id = joueur.IdTournament});
                }

                ViewBag.error = retourApi.Message;
            }

            var temp = await CallAPI.GetTournoi(joueur.IdTournament);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;

            ViewBag.NbDeck = tournoi.DeckListNumber;
            ViewData["Title"] = "S'inscire pour " + tournoi.Name;
            return View("~/Views/Tournoi/Register.cshtml", joueur);
        }

        public async Task<ActionResult> Unregister(int IdTournoi, string error = null)
        {
            if (IdTournoi < 1 || !int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
            {
                return NotFound();
            }
           
           var temp = await CallAPI.GetTournoi(IdTournoi);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;

            ViewBag.error = error;
            ViewData["Title"] = "Se désinscrire pour " + tournoi.Name;
            return View("~/Views/Tournoi/Unregister.cshtml", tournoi);
        }

        // POST: Decks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Unregister([Bind("IdTournament")] Tournoi Tournoi)
        {
            if (Tournoi.IdTournament < 1 || !int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
            {
                return NotFound();
            }

            var joueur = new Joueur();
            
            joueur.User.IdUser = IdUser;
            joueur.IdTournament = Tournoi.IdTournament;


            RetourAPI retourApi = await CallAPI.UnregisterTournoi(joueur);
            if (retourApi.Succes)
            {
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Unregister", new{ IdTournoi = Tournoi.IdTournament, error = retourApi.Message});
        }

        public async Task<IActionResult> UpdateMatch(int idT, int rn, int idP1, string error = null)
        {
            Match match = await CallAPI.GetMatch(idT, rn, idP1);
            if (match.IdTournament == 0)
            {
                return NotFound();
            }

            var decksP1 = await CallAPI.GetDeckOfPlayer(match.IdTournament, match.IdPlayer1);
            ViewData["DecksP1"] = decksP1;
            var decksP2 = await CallAPI.GetDeckOfPlayer(match.IdTournament, match.IdPlayer2);
            ViewData["DecksP2"] = decksP2;

            if (!int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser) ||
                (match.IdPlayer1 != IdUser && match.IdPlayer2 != IdUser))
            {
                ViewData["Title"] = "Match";
                return View("~/Views/Tournoi/Match.cshtml", match);
            }

            var empyParties = new List<ViewPartie>
            {
                new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie(),
                new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie()
            };

            if (match.Parties == null)
            {
                match.Parties = empyParties;
            }

            match.Parties = match.Parties.OrderBy(p => p.PartNumber).Concat(empyParties).Take((match.Tournament.DeckListNumber * 2) - 1).ToList();
            List<ViewPartie> temp = new List<ViewPartie>();
            int i = 1;
            foreach (var p in match.Parties)
            {
                if (p.PartNumber == 0)
                {
                    p.PartNumber = i;
                    i++;
                }
                else if (p.PartNumber >= i)
                {
                    i = p.PartNumber + 1;
                }

                temp.Add(p);
            }

            match.Parties = temp;
            ViewBag.error = error;
            ViewData["Title"] = "Match";
            return View("~/Views/Tournoi/Match.cshtml", match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMatch([Bind("IdTournament, RoundNumber, IdPlayer1, IdPlayer2, Parties")]
            Match match)
        {
            if (match.IdTournament == 0 || !int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser) || (match.IdPlayer1 != IdUser && match.IdPlayer2 != IdUser))
            {
                return NotFound();
            }

            var Parties = match.Parties;
            var retourApis = new List<RetourAPI>();
            foreach (var p in Parties)
            {
                p.IdTournament = match.IdTournament;
                p.RoundNumber = match.RoundNumber;
                p.IdPlayer1 = match.IdPlayer1;
                p.IdPlayer2 = match.IdPlayer2;
                if (p.ResultPart != null)
                {
                    retourApis.Add(await CallAPI.CreatePartie(p));
                }
            }

            string error = null;
            if (retourApis.Count > 0 && retourApis.All(r => r.Succes))
            {
                error = "Vérifier que les resulta entré sont correcte!";
            }
            return RedirectToAction("UpdateMatch", new{ idT = match.IdTournament, rn = match.RoundNumber, idP1 = match.IdPlayer1, error });
        }

        public async Task<IActionResult> EditDeck(int IdTournoi, string error = null)
        {
            if (IdTournoi < 1 || !int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
            {
                return NotFound();
            }

            Joueur joueur = await CallAPI.GetJoueur(IdTournoi, IdUser);

            if (joueur == null)
            {
                return NotFound();
            }

            ViewBag.error = error;
            ViewData["Title"] = "Modifier mes decks";
            return View("~/Views/Tournoi/EditDeck.cshtml", joueur);
        }

        // POST: Decks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDeck([Bind("Deck, IdTournament")] Joueur joueur)
        {
            if (joueur.IdTournament < 1 || !int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
            {
                return NotFound();
            }

            string error = null;
            if (ModelState.IsValid)
            {
                joueur.User.IdUser = IdUser;


                var retourApis = new List<RetourAPI>();
                foreach (var d in joueur.Decks)
                {
                    
                    retourApis.Add(await CallAPI.EditDeck(d));

                }

                if (retourApis.Count > 0 && retourApis.All(r => r.Succes))
                {
                    return RedirectToAction("Details", "Tournois", new { id = joueur.IdTournament });
                }

                error = string.Join("<br/>", retourApis.Where(r => !(r.Succes)).Select(r => r.Message));
            }

            return RedirectToAction("EditDeck", new {IdTournoi = joueur.IdTournament, error = error});
        }




        public async Task<ActionResult> Drop(int IdTournoi, string error = null)
        {
            if (IdTournoi < 1 || !int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
            {
                return NotFound();
            }

            var temp = await CallAPI.GetTournoi(IdTournoi);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;

            ViewBag.error = error;
            ViewData["Title"] = "Abandonner " + tournoi.Name;
            return View("~/Views/Tournoi/Drop.cshtml", tournoi);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Drop([Bind("IdTournament")] Tournoi Tournoi)
        {
            if (Tournoi.IdTournament < 1 || !int.TryParse(HttpContext.Session.GetString("UserId"), out int IdUser))
            {
                return NotFound();
            }

            var joueur = new Joueur();

            joueur.User.IdUser = IdUser;
            joueur.IdTournament = Tournoi.IdTournament;


            RetourAPI retourApi = await CallAPI.DropTournoi(joueur);
            if (retourApi.Succes)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Drop", new { IdTournoi = Tournoi.IdTournament, error = retourApi.Message });
        }

    }
}