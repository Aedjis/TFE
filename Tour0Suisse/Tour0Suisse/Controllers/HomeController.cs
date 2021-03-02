using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tour0Suisse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace Tour0Suisse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Connexion()
        {
            ViewData["Message"] = "Page de connexion";
            return View();
        }
        public IActionResult Profil()
        {
            ViewData["Message"] = "Page de profil";
            return View();
        }

        public IActionResult Tournoi()
        {
            ViewData["Message"] = "Page des tournoi";

            return View();
        }

        public IActionResult Inscription()
        {
            ViewData["Message"] = "Page d'inscription";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
