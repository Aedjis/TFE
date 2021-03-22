using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tour0Suisse.Web.Data;
using Tour0Suisse.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Tour0Suisse.Controllers;

namespace Tour0Suisse.Web.Controllers
{
    public class TournoisController : Controller
    {
        private readonly APIcontext _context;

        public TournoisController(APIcontext context)
        {
            _context = context;
        }

        // GET: Tournois
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Tournois
        public async Task<IActionResult> ListTournoi()
        {
            return View("~/Views/Tournoi/ListTournoi.cshtml", await _context.Tournoi.ToListAsync());
        }

        // GET: Tournois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournoi
                .FirstOrDefaultAsync(m => m.IdTournament == id);
            if (tournoi == null)
            {
                return NotFound();
            }

            return View(tournoi);
        }

        // GET: Tournois/Create
        public IActionResult Create()
        {
            //List<Jeu> Test = new List<Jeu>();
            //for (int i = 0; i < 5; i++)
            //{
            //    Test.Add( new Jeu
            //    {
            //        IdGame = i,
            //        Name = "jeu numero " + i
            //    });
            //}
            ViewData["IdGame"] = new SelectList(_context.Jeu, "IdGame", "Name");
            return View("~/Views/Tournoi/CreateTournoi.cshtml");
        }

        // POST: Tournois/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTournament,Name,Date,Desciption,IdGame,MaxNumberPlayer,DeckListNumber,Ppwin,Ppdraw,Pplose,Over,Deleted")] Tournoi tournoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tournoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGame"] = new SelectList(_context.Jeu, "IdGame", "Name", tournoi.IdGame);
            return View("~/Views/Tournoi/CreateTournoi.cshtml", tournoi);
        }

        // GET: Tournois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournoi.FindAsync(id);
            if (tournoi == null)
            {
                return NotFound();
            }
            ViewData["IdGame"] = new SelectList(_context.Jeu, "IdGame", "Name", tournoi.IdGame);
            return View(tournoi);
        }

        // POST: Tournois/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTournament,Name,Date,Desciption,IdGame,MaxNumberPlayer,DeckListNumber,Ppwin,Ppdraw,Pplose,Over,Deleted")] Tournoi tournoi)
        {
            if (id != tournoi.IdTournament)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tournoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournoiExists(tournoi.IdTournament))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGame"] = new SelectList(_context.Jeu, "IdGame", "Name", tournoi.IdGame);
            return View(tournoi);
        }

        // GET: Tournois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournoi
                .FirstOrDefaultAsync(m => m.IdTournament == id);
            if (tournoi == null)
            {
                return NotFound();
            }

            return View(tournoi);
        }

        // POST: Tournois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tournoi = await _context.Tournoi.FindAsync(id);
            _context.Tournoi.Remove(tournoi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TournoiExists(int id)
        {
            return _context.Tournoi.Any(e => e.IdTournament == id);
        }
    }
}