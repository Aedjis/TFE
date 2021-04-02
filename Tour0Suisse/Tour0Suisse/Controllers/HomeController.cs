using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tour0Suisse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using Tour0Suisse.Model;

namespace Tour0Suisse.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            List<ViewTournament> ListTournois;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44321/View/GetTournaments"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ListTournois = JsonConvert.DeserializeObject<IEnumerable<ViewTournament>>(apiResponse).ToList();
                }
            }

            ViewBag.NextTournament = ListTournois.Where(t => t.Date > DateTime.Now && !t.Over && t.Deleted == null)
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
