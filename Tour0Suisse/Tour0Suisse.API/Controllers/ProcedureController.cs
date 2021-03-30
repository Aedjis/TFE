using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour0Suisse.Model;
using Tour0Suisse.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tour0Suisse.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        static private DBTour0SuisseLINQ DB_CURD;

        static  ProcedureController()
        {
            string ConnectionString =
                "Server=DESKTOP-BNVQBMF;Database=Tour0Suisse;user id=API_User;password=1234@Test;";

            DB_CURD = new DBTour0SuisseLINQ(ConnectionString);
        }

        #region User
        
        [HttpPost]
        public ViewUser LogIN(Utilisateur User)
        {
            return DB_CURD.LogIn(User.Email, User.HexaPassword); ;
        }

        [HttpPost]
        public bool CreateUser(Utilisateur User)
        {
            return DB_CURD.CreateUser(User); ;
        }

        [HttpPost]
        public bool EditUser(Utilisateur User)
        {
            return DB_CURD.EditUser(User); ;
        }

        [HttpPost]
        public bool DeleteUser(Utilisateur User)
        {
            return DB_CURD.DeleteUser(User); ;
        }

        [HttpPost]
        public bool AddPseudo(PseudoIg Pseudo)
        {
            return DB_CURD.AddPseudoIG(Pseudo); ;
        }

        [HttpPost]
        public bool EditPseudo(PseudoIg Pseudo)
        {
            return DB_CURD.EditPseudoIG(Pseudo); ;
        }

        [HttpPost]
        public bool DeletePseudo(PseudoIg Pseudo)
        {
            return DB_CURD.DeletePseudoIG(Pseudo); ;
        }

        #endregion


        #region Tournoi

        [HttpPost]
        public int CreateTournoi(Tournoi Tournoi)
        {
            return DB_CURD.CreateTournoi(Tournoi); ;
        }

        [HttpPost]
        public bool EditTournoi(ViewTournament Tournoi)
        {
            return DB_CURD.EditTournoi(Tournoi); ;
        }

        [HttpPost]
        public bool DeleteTournoi(int id)
        {
            return DB_CURD.DeleteTournoi(new Tournoi{IdTournament = id}); ;
        }

        [HttpPost]
        public bool AddAdmin(ViewOrga Orga)
        {
            return DB_CURD.AddAdmin(Orga); ;
        }

        [HttpPost]
        public bool EditAdmin(ViewOrga Orga)
        {
            return DB_CURD.EditAdmin(Orga); ;
        }

        [HttpPost]
        public bool DeleteAdmin(ViewOrga Orga)
        {
            return DB_CURD.DeleteAdmin(Orga); ;
        }

        [HttpPost]
        public bool CreateRound(Round Round)
        {
            return DB_CURD.CreateRound(Round); ;
        }

        [HttpPost]
        public bool EditRound(Round Round)
        {
            return DB_CURD.EditRound(Round); ;
        }

        [HttpPost]
        public bool DeleteRound(Round Round)
        {
            return DB_CURD.DeleteRound(Round); ;
        }

        [HttpPost]
        public bool DeleteRoundAndMatch(Round Round)
        {
            return DB_CURD.DeleteRoundAndMatch(Round); ;
        }

        [HttpPost]
        public bool CreateMatch(ViewMatch Match)
        {
            return DB_CURD.CreateMatch(Match); ;
        }

        [HttpPost]
        public bool CreateMatchAllPairing(Round Round)
        {
            var Players = new List<int>();
            foreach (var p in DB_CURD.GetParticipantsOf(Round.IdTournament))
            {
                if (!p.Drop)
                {
                    Players.Add(p.IdUser);
                }
            }

            var Classements = DB_CURD.GetScoreClassementTemporairesOfTournamnent(Round.IdTournament);
            var Matches = DB_CURD.GetMatchesOf(Round.IdTournament);
            var Tournoi = DB_CURD.GetTournament(Round.IdTournament);

            List<PairID> PairingList = AlgoPairing.Pairing(Players, Classements, Matches, Round.RoundNumber, Tournoi.Ppwin, Tournoi.Ppdraw, Tournoi.Pplose);

            return DB_CURD.CreateMatchAllParing(Round, PairingList); ;
        }

        [HttpPost]
        public bool EditMatch(ViewMatch Match, int P1, int P2)
        {
            return DB_CURD.EditMatch(Match, new PairID{ID1 = P1, ID2 = P2}); ;
        }

        [HttpPost]
        public bool DeleteMatch(ViewMatch Match)
        {
            return DB_CURD.DeleteMatch(Match); ;
        }


        #endregion

        #region Jeu

        [HttpPost]
        public bool CreateJeu(Jeu Jeu)
        {
            return DB_CURD.AddGame(Jeu); ;
        }

        [HttpPost]
        public bool EditJeu(Jeu Jeu)
        {
            return DB_CURD.EditGame(Jeu); ;
        }

        [HttpPost]
        public bool DeleteJeu(Jeu Jeu)
        {
            return DB_CURD.DeleteGame(Jeu); ;
        }

        #endregion

        //// GET api/<ProcedureController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProcedureController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProcedureController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProcedureController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
