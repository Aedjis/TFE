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
#warning a refaire
        //private readonly APIcontext _context;

        //public TournoisController(APIcontext context)
        //{
        //    _context = context;
        //}

        // GET: Tournois
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
#warning a refaire
        //// GET: Tournois
        //public async Task<IActionResult> ListTournoi()
        //{

        //    return View("~/Views/Tournoi/ListTournoi.cshtml", await _context.Tournoi.ToListAsync());
        //}
#warning a refaire
        //// GET: Tournois/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tournoi = await _context.Tournoi
        //        .FirstOrDefaultAsync(m => m.IdTournament == id);
        //    if (tournoi == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tournoi);
        //}

        
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
#warning a refaire
        //// GET: Tournois/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tournoi = await _context.Tournoi.FindAsync(id);
        //    if (tournoi == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdGame"] = new SelectList(_context.Jeu, "IdGame", "Name", tournoi.IdGame);
        //    return View(tournoi);
        //}
#warning a refaire
        //// POST: Tournois/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("IdTournament,Name,Date,Desciption,IdGame,MaxNumberPlayer,DeckListNumber,Ppwin,Ppdraw,Pplose,Over,Deleted")] Tournoi tournoi)
        //{
        //    if (id != tournoi.IdTournament)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tournoi);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TournoiExists(tournoi.IdTournament))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdGame"] = new SelectList(_context.Jeu, "IdGame", "Name", tournoi.IdGame);
        //    return View(tournoi);
        //}
#warning a refaire
        //// GET: Tournois/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tournoi = await _context.Tournoi
        //        .FirstOrDefaultAsync(m => m.IdTournament == id);
        //    if (tournoi == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tournoi);
        //}
#warning a refaire
        //// POST: Tournois/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var tournoi = await _context.Tournoi.FindAsync(id);
        //    _context.Tournoi.Remove(tournoi);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TournoiExists(int id)
        //{
        //    return _context.Tournoi.Any(e => e.IdTournament == id);
        //}
    }
}