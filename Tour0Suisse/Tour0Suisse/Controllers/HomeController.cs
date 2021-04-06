using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tour0Suisse.Model;
using Tour0Suisse.Models;
using Tour0Suisse.Web.Procedure;

namespace Tour0Suisse.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ViewTournament> listTournois = (await CallAPI.GetAllTournaments()).ToList();
            

            ViewBag.NextTournament = listTournois.Where(t => t.Date > DateTime.Now && !t.Over && t.Deleted == null)
                .OrderBy(t => t.Date).Take(15).TakeLast(10);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
