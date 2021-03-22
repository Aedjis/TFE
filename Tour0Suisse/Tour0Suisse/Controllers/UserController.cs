using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using  Tour0Suisse.Model;
using Tour0Suisse.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Tour0Suisse.Controllers
{

    public class UserController : Controller
    {

        private readonly APIcontext _context;

        public UserController(APIcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Utilisateurs
        public async Task<IActionResult> AllUser()
        {
            return View(await _context.Utilisateur.ToListAsync());
        }

        // GET: User
        public ActionResult LogIn()
        {
            return View("~/Views/User/Connexion.cshtml");
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View("~/Views/User/Profil.cshtml");
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
        public async Task<IActionResult> Create([Bind("IdUser,Pseudo,Email,Password,Organizer,Deleted")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                //todo faire l'appelle a api pour cré un nouvelle utilisateur (encrypté le mdp avant aussi)

                //_context.Add(utilisateur);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

                return View("~/Views/User/InscriptionReussie.cshtml");
            }
            return View("~/Views/User/Inscription.cshtml", utilisateur);
        }


        // GET: User/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateur.FindAsync(id);
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
            if (id != utilisateur.IdUser)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilisateurExists(utilisateur.IdUser))
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

            return View("~/Views/User/UpdateProfil.cshtml", utilisateur);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View("~/Views/User/DeletedCompte.cshtml");
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilisateur = await _context.Utilisateur.FindAsync(id);
            _context.Utilisateur.Remove(utilisateur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateurExists(int id)
        {
            return _context.Utilisateur.Any(e => e.IdUser == id);
        }
    }
}