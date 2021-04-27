using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tour0Suisse.Model;
using Tour0Suisse.Web.Procedure;

namespace Tour0Suisse.Web.Controllers
{
    public class AdminController : Controller
    {
        public async Task<ActionResult> Index()
        {
            int UserId = int.TryParse(HttpContext.Session.GetString("UserId"), out int i) ? i : 0;
            if (UserId == 0)
            {
                return NotFound();
            }
            

            IEnumerable<ViewTournament> tournaments = (await CallAPI.GetTournamentsWHereOrga(UserId)).OrderBy(t => t.Over).ThenBy(t => t.Date);

            return View("~/Views/Admin/Index.cshtml", tournaments);
        }

        public async Task<ActionResult> Tournoi(int id)
        {
            var temp = await CallAPI.GetTournoi(id);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;
            

            return View("~/Views/Admin/Tournoi.cshtml", tournoi);
        }

        public async Task<IActionResult> Start(int id)
        {
            var temp = await CallAPI.GetTournoi(id);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;

            if (tournoi.Over)
            {
                return RedirectToAction("Tournoi", new{id});
            }

            RetourAPI retour = await CallAPI.StartTournoi(tournoi);
            if (!retour.Succes)
            {
                //
            }

            return RedirectToAction("Tournoi", new {id = id});
        }

        public async Task<IActionResult> EndRound(int id, int round)
        {
            var temp = await CallAPI.GetTournoi(id);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;

            if (tournoi.Over)
            {
                return NotFound();
            }

            RetourAPI retour = await CallAPI.EndRound(id, round);
            if (!retour.Succes)
            {
                //
            }

            return RedirectToAction("Tournoi", new {id = id});
        }

        public async Task<IActionResult> Pairing(int id, int round)
        {
            var temp = await CallAPI.GetTournoi(id);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;

            if (tournoi.Over)
            {
                return NotFound();
            }

            RetourAPI retour = await CallAPI.PairingRound(new Round {IdTournament = id, RoundNumber = round});
            if (!retour.Succes)
            {
                //
            }

            return RedirectToAction("Tournoi", new {id = id});
        }

        public async Task<IActionResult> UpdateMatch(int idT, int rn, int idP1)
        {
            Match match = await CallAPI.GetMatch(idT, rn, idP1);
            if (match.IdTournament == 0)
            {
                return NotFound();
            }

            var decksP1 = await CallAPI.GetDeckOfPlayer(match.IdTournament, match.IdPlayer1);
            ViewData["DecksP1"] = decksP1;
            var decksP2= await CallAPI.GetDeckOfPlayer(match.IdTournament, match.IdPlayer2);
            ViewData["DecksP2"] = decksP2;

            var empyParties = new List<ViewPartie>
            {
                new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie(),
                new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie()
            };

            if (match.Parties == null)
            {
                match.Parties = empyParties;
            }

            match.Parties = match.Parties.OrderBy(p=>p.PartNumber).Concat(empyParties).Take((match.Tournament.DeckListNumber * 2) - 1).ToList();
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
            
            return View("~/Views/Admin/Match.cshtml", match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMatch([Bind("IdTournament, RoundNumber, IdPlayer1, IdPlayer2, Parties")]
            Match match)
        {
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
                    retourApis.Add(await CallAPI.CreateOrUpdatePartie(p));
                }
            }

            if (retourApis.Count > 0 && retourApis.All(r => r.Succes))
            {
                return RedirectToAction("Tournoi", new {id = match.IdTournament});
            }

            match = await CallAPI.GetMatch(match.IdTournament, match.RoundNumber, match.IdPlayer1);
            if (match.IdTournament == 0)
            {
                return NotFound();
            }

            match.Parties = Parties;

            var decksP1 = await CallAPI.GetDeckOfPlayer(match.IdTournament, match.IdPlayer1);
            ViewData["DecksP1"] = decksP1.Append(new ViewDeck());
            var decksP2 = await CallAPI.GetDeckOfPlayer(match.IdTournament, match.IdPlayer2);
            ViewData["DecksP2"] = decksP2.Append(new ViewDeck());

            var empyParties = new List<ViewPartie>
            {
                new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie(),
                new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie(), new ViewPartie()
            };

            if (match.Parties == null)
            {
                match.Parties = empyParties;
            }

            match.Parties = match.Parties.Concat(empyParties).Take((match.Tournament.DeckListNumber*2)-1).ToList();
            return View("~/Views/Admin/Match.cshtml", match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNextRound(int id, int round)
        {
            var temp = await CallAPI.GetTournoi(id);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;

            if (tournoi.Over)
            {
                return NotFound();
            }

            RetourAPI retour = await CallAPI.CreateRound(new Round {IdTournament = id, RoundNumber = (round + 1), StartRound = DateTime.UtcNow});
            if (!retour.Succes)
            {
                //
            }

            return RedirectToAction("Tournoi", new {id = id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EndTournoi(Tournoi tournoi)
        {
            if (tournoi == null || tournoi.IdTournament < 1 || tournoi.Deleted != null)
            {
                return NotFound();
            }

            if (tournoi.Deleted != null)
            {
                return NotFound();
            }

            if (tournoi.Over)
            {
                return NotFound();
            }

            RetourAPI retour = await CallAPI.EndTournoi(tournoi);
            if (retour.Succes)
            {
                return RedirectToAction("Details", "Tournois", new {id = tournoi.IdTournament});
            }

            return RedirectToAction("EndTournoi", new {id = tournoi.IdTournament});
        }
        
        public async Task<IActionResult> EndTournoiR(int id)
        {
            var temp = await CallAPI.GetTournoi(id);

            if (temp.Item1)
            {
                return NotFound();
            }

            Tournoi tournoi = temp.Item2;

            if (tournoi.Over)
            {
                return NotFound();
            }

            //return RedirectToAction("Details", "Tournois", new { id = id });
            tournoi.Resultas = tournoi.Resultas.OrderByDescending(r => r.Score);
            return View("~/Views/Admin/EndTournoi.cshtml", tournoi);
        }
    }
}
