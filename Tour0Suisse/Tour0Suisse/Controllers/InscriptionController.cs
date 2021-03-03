using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tour0Suisse.Controllers
{
    public class InscriptionController : Controller
    {
        // GET: Inscription/Create
        public ActionResult Create()
        {
            return View("InscriptionReussie");
        }

        // POST: Inscription/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return View("InscriptionReussie");
            }
            catch
            {
                return View("Inscription");
            }
        }
    }
}