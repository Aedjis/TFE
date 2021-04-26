using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tour0Suisse.Model;

namespace Tour0Suisse.Web.Procedure
{
    public static partial class CallAPI
    {
        public static async Task<Tournoi> GetTournoiById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response =
                    await httpClient.GetAsync(_BaseUri + "/View/GetTournament?id=" + id.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Tournoi>(apiResponse);
                }
            }
        }

        public static async Task<IEnumerable<ViewTournament>> GetAllTournaments()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_BaseUri+"/View/GetTournaments"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<ViewTournament>>(apiResponse);
                }
            }
        }

        public static async Task<IEnumerable<ViewJeu>> GetAllJeus()
        {
            IEnumerable<ViewJeu> Jeus;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_BaseUri + "/View/GetJeus"))
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
                string requestUri = _BaseUri + "/View/GetUser?id=" + id.ToString();
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<Utilisateur>(apiResponse);
                }
            }

            return user;
        }

        public static async Task<IEnumerable<ViewUser>> GetAllUtilisateurs()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_BaseUri + "/View/GetUsers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<ViewUser>>(apiResponse);
                }
            }
        }

        public static async Task<ViewUser> Login(Utilisateur user)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(_BaseUri + "/Procedure/LogIN", user))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ViewUser>(apiResponse);
                }
            }
        }

        public static async Task<Utilisateur> GetUtilisateurById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                string requestUri = _BaseUri+"/View/GetUser?id=" + id.ToString();
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Utilisateur>(apiResponse);
                }
            }
        }

        public static async Task<IEnumerable<ViewRound>> GetRounds(int id)
        {
            using (var httpClient = new HttpClient())
            {
                string requestUri = _BaseUri + "/View/GetRoundsOfTournament?IdTournoi=" + id.ToString();
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<ViewRound>>(apiResponse);
                }
            }
        }

        public static async Task<IEnumerable<ViewTournament>> GetTournamentsWHereOrga(int id)
        {
            return await _GetT<IEnumerable<ViewTournament>>("/View/GetTournamentsWHereOrga?id=" + id.ToString());
        }

        private static async Task<T> _GetT<T>(string endRequestUri, int? id = null)
        {
            using (var httpClient = new HttpClient())
            {
                string requestUri = _BaseUri + endRequestUri + ((id !=null)? id.ToString() : "");
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }
        }

        public static async Task<Match> GetMatch(int idT, int rn, int idP1)
        {
            using (var httpClient = new HttpClient())
            {
                string requestUri = _BaseUri + "/View/GetMatchOfPlayerForTournamentForRound?IdTournoi=" + idT + "&IdPlayer=" + idP1 + "&RoundNumber=" + rn;
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Match>(apiResponse);
                }
            }
        }

        public static async Task<Joueur> GetJoueur(int idT, int idP1)
        {
            using (var httpClient = new HttpClient())
            {
                string requestUri = _BaseUri + "/View/GetParticipant?IdTournoi=" + idT + "&IdPlayer=" + idP1;
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Joueur>(apiResponse);
                }
            }
        }

        public static async Task<IEnumerable<ViewDeck>> GetDeckOfPlayer(int idT, int idP1)
        {
            using (var httpClient = new HttpClient())
            {
                string requestUri = _BaseUri + "/View/GetDeckOfPlayer?IdTournoi=" + idT + "&IdUser=" + idP1;
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<ViewDeck>>(apiResponse);
                }
            }
        }

    }
}
