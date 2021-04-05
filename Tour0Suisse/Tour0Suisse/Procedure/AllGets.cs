using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tour0Suisse.Model;

namespace Tour0Suisse.Web.Procedure
{
    public static class CallAPI
    {
        public static async Task<IEnumerable<ViewJeu>> GetAllJeus()
        {
            IEnumerable<ViewJeu> Jeus;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44321/View/GetJeus"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Jeus = JsonConvert.DeserializeObject<IEnumerable<ViewJeu>>(apiResponse);
                }
            }

            return Jeus;
        }

        public static async Task<Utilisateur> GetUser(int id)
        {
            Utilisateur user;

            using (var httpClient = new HttpClient())
            {
                string requestUri = "https://localhost:44321" + "/View" + "/GetUser" + "?id=" + id.ToString();
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<Utilisateur>(apiResponse);
                }
            }

            return user;
        }
    }
}
