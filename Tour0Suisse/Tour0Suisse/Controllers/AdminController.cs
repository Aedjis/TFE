using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Tour0Suisse.Model;
using Tour0Suisse.Web.Procedure;

namespace Tour0Suisse.Web.Controllers
{
    public class AdminController : Controller
    {
        public async Task<ActionResult> Index()
        {
            int UserId;
            try
            {
                UserId = int.Parse(HttpContext.Session.GetString("UserId"));
            }
            catch (Exception ex)
            {
                UserId = 0;
            }

            if (UserId == 0)
            {
                return NotFound();
            }
            

            IEnumerable<ViewTournament> tournaments = (await CallAPI.GetTournamentsWHereOrga(UserId)).OrderBy(t=>t.Over).ThenBy(t=>t.Date);

            return View("~/Views/Admin/Index.cshtml", tournaments);
        }

        public async Task<ActionResult> Tournoi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournoi tournoi = await CallAPI.GetTournoiById((int)id);

            if (tournoi == null || tournoi.IdTournament < 1 || tournoi.Deleted != null)
            {
                return NotFound();
            }

            if (tournoi.Over)
            {
                return RedirectToAction();
            }

            ViewData["Tournoi"] = tournoi;
            List<Round> rounds = new List<Round>();
            foreach (var vr in await CallAPI.GetRounds(tournoi.IdTournament))
            {
                rounds.Add(vr.CreateRoundFromView(tournoi.Matchs));
            }

            return View("~/Views/Admin/Tournoi.cshtml", rounds);
        }

        public async Task<IActionResult> Start(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournoi tournoi = await CallAPI.GetTournoiById((int)id);

            if (tournoi == null || tournoi.IdTournament < 1 || tournoi.Deleted != null)
            {
                return NotFound();
            }

            if (tournoi.Over)
            {
                return NotFound();
            }

            RetourAPI retour = await CallAPI.StartTournoi(tournoi);
            if (!retour.Succes)
            {

            }

            return RedirectToAction("Tournoi", new { id = id });
        }

        public async Task<IActionResult> Pairing(int id, int round)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournoi tournoi = await CallAPI.GetTournoiById((int)id);

            if (tournoi == null || tournoi.IdTournament < 1 || tournoi.Deleted != null)
            {
                return NotFound();
            }

            if (tournoi.Over)
            {
                return NotFound();
            }

            RetourAPI retour = await CallAPI.PairingRound(new Round { IdTournament = id, RoundNumber = round });
            if (!retour.Succes)
            {

            }

            return RedirectToAction("Tournoi", new { id = id });
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
                new ViewPartie(), new ViewPartie()
            };

            if (match.Parties == null)
            {
                match.Parties = empyParties;
            }

            var temp = (decksP1.Count() + decksP2.Count());
            match.Parties = match.Parties.Concat(empyParties).Take((temp / 2) + temp % 2);
            return View("~/Views/Admin/Match.cshtml", match);
        }
    }
}
