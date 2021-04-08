using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators.Internal;
using Newtonsoft.Json;
using Tour0Suisse.Model;

namespace Tour0Suisse.Web.Procedure
{
    public static partial class  CallAPI
    {
        public static async Task<RetourAPI> InsertTournoi(Tournoi tournoi)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response =
                    await httpClient.PostAsJsonAsync(_BaseUri + "/Procedure/CreateTournoi",
                        tournoi))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RetourAPI>(apiResponse);
                }
            }
        }

        public static async Task<RetourAPI> UpdateTournoi(Tournoi tournoi)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response =
                    await httpClient.PostAsJsonAsync(_BaseUri + "/Procedure/EditTournoi",
                        tournoi))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RetourAPI>(apiResponse);
                }
            }
        }

        public static async Task<RetourAPI> DeleteTournoi(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response =
                    await httpClient.PostAsJsonAsync(_BaseUri + "/Procedure/DeleteTournoi",
                        id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RetourAPI>(apiResponse);
                }
            }
        }

        public static async Task<RetourAPI> RegisterTournoi(Joueur joueur)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response =
                    await httpClient.PostAsJsonAsync(_BaseUri + "/Procedure/Register",
                        joueur))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RetourAPI>(apiResponse);
                }
            }
        }

        public static async Task<RetourAPI> InsertUser(Utilisateur user)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(_BaseUri + "/Procedure/CreateUser", user))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RetourAPI>(apiResponse);
                }
            }
        }

        public static async Task<RetourAPI> StartTournoi(Tournoi t)
        {
            return await _PostT("/Procedure/CreateRound",
                new Round {IdTournament = t.IdTournament, StartRound = (t.Date < DateTime.UtcNow) ? t.Date : DateTime.UtcNow, RoundNumber = 1});
        }

        private static async Task<RetourAPI> _PostT<T>(string endRequestUri, T o)
        {
            using (var httpClient = new HttpClient())
            {
                string requestUri = _BaseUri + endRequestUri;
                using (var response = await httpClient.PostAsJsonAsync(requestUri, o))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RetourAPI>(apiResponse);
                }
            }
        }

        public static async Task<RetourAPI> PairingRound(Round Round)
        {
            return await _PostT("/Procedure/CreateMatchAllPairing", Round);
        }

        public static async Task<RetourAPI> CreateOrUpdatePartie(ViewPartie Partie)
        {
            return await _PostT("/Procedure/CreateOrUpdatePartie", Partie);
        }
    }
}
