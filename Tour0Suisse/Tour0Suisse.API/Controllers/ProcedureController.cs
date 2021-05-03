using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tour0Suisse.Model;
using Tour0Suisse.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tour0Suisse.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private static readonly DBTour0SuisseLINQ DB_CURD;

        static ProcedureController()
        {
            string ConnectionString =
                "Server=DESKTOP-BNVQBMF;Database=Tour0Suisse;user id=API_User;password=1234@Test;";

            DB_CURD = new DBTour0SuisseLINQ(ConnectionString);
        }

        #region User

        [HttpPost]
        public ViewUser LogIN(Utilisateur Utilisateur)
        {
            return DB_CURD.LogIn(Utilisateur.Email, Utilisateur.HexaPassword);
        }

        [HttpPost]
        public RetourAPI CreateUser(Utilisateur Utilisateur)
        {
            return DB_CURD.CreateUser(Utilisateur);
        }

        [HttpPost]
        public RetourAPI EditUser(Utilisateur Utilisateur)
        {
            return DB_CURD.EditUser(Utilisateur);
        }

        [HttpPost]
        public RetourAPI DeleteUser(Utilisateur Utilisateur)
        {
            return DB_CURD.DeleteUser(Utilisateur);
        }

        [HttpPost]
        public RetourAPI UpdateUserIgPseudo(Utilisateur Utilisateur)
        {
            List<ViewPseudo> ListPseudo = DB_CURD.GetPseudosUser(Utilisateur.IdUser);

            int count = 0;
            int reussite = 0;

            foreach (ViewPseudo pseudo in Utilisateur.PseudoIgs)
                if (!ListPseudo.Contains(pseudo))
                {
                    count++;
                    if (ListPseudo.Any(p => p.IdGame == pseudo.IdGame))
                    {
                        if (string.IsNullOrWhiteSpace(pseudo.IgPseudo) && DB_CURD.DeletePseudoIG(pseudo).Succes)
                            reussite++;
                        else if (DB_CURD.EditPseudoIG(pseudo).Succes) reussite++;
                    }
                    else if (string.IsNullOrEmpty(pseudo.IgPseudo))
                    {
                        count--;
                    }
                    else if (DB_CURD.AddPseudoIG(pseudo).Succes)
                    {
                        reussite++;
                    }
                }

            return new RetourAPI(reussite == count,
                reussite + " Pseudo sur " + count + " on ete mis a jours");
        }

        //[HttpPost]
        //public RetourAPI AddPseudo(PseudoIg Pseudo)
        //{
        //    return DB_CURD.AddPseudoIG(Pseudo); ;
        //}

        //[HttpPost]
        //public RetourAPI EditPseudo(PseudoIg Pseudo)
        //{
        //    return DB_CURD.EditPseudoIG(Pseudo); ;
        //}

        //[HttpPost]
        //public RetourAPI DeletePseudo(PseudoIg Pseudo)
        //{
        //    return DB_CURD.DeletePseudoIG(Pseudo); ;
        //}

        #endregion


        #region Tournoi

        [HttpPost]
        public RetourAPI CreateTournoi(Tournoi Tournoi)
        {
            return DB_CURD.CreateTournoi(Tournoi);
        }

        [HttpPost]
        public RetourAPI EditTournoi(Tournoi Tournoi)
        {
            return DB_CURD.EditTournoi(Tournoi);
        }

        [HttpPost]
        public RetourAPI DeleteTournoi(int id)
        {
            return DB_CURD.DeleteTournoi(new Tournoi {IdTournament = id});
        }

        [HttpPost]
        public RetourAPI EndTournoi(Tournoi Tournoi)
        {
            return DB_CURD.EndTournoi(Tournoi);
        }

        [HttpPost]
        public RetourAPI Register(Joueur Joueur)
        {
            return DB_CURD.RegisterTournoi(
                new DeckJoueur {IdDeck = 0, IdTournament = Joueur.IdTournament, IdUser = Joueur.User.IdUser},
                Joueur.Decks.Select(d => d.DeckList).ToList());
        }

        [HttpPost]
        public RetourAPI EditDecks(ViewDeck Deck)
        {
            return DB_CURD.UpdateDeck(
                new DeckJoueur {IdDeck = Deck.IdDeck, IdTournament = Deck.IdTournament, IdUser = Deck.IdUser},
                Deck.DeckList);
        }

        [HttpPost]
        public RetourAPI Unregister(Joueur Joueur)
        {
            return DB_CURD.UnregisterTournoi(Joueur);
        }

        [HttpPost]
        public RetourAPI AddAdmin(ViewOrga Orga)
        {
            return DB_CURD.AddAdmin(Orga);
        }

        [HttpPost]
        public RetourAPI EditAdmin(ViewOrga Orga)
        {
            return DB_CURD.EditAdmin(Orga);
        }

        [HttpPost]
        public RetourAPI DeleteAdmin(ViewOrga Orga)
        {
            return DB_CURD.DeleteAdmin(Orga);
        }

        [HttpPost]
        public RetourAPI CreateRound(Round Round)
        {
            return DB_CURD.CreateRound(Round);
        }

        [HttpPost]
        public RetourAPI EditRound(Round Round)
        {
            return DB_CURD.EditRound(Round);
        }

        [HttpPost]
        public RetourAPI EndRound(Round Round)
        {
            return DB_CURD.EndRound(Round);
        }

        [HttpPost]
        public RetourAPI DeleteRound(Round Round)
        {
            return DB_CURD.DeleteRound(Round);
        }

        [HttpPost]
        public RetourAPI DeleteRoundAndMatch(Round Round)
        {
            return DB_CURD.DeleteRoundAndMatch(Round);
        }

        [HttpPost]
        public RetourAPI CreateMatch(ViewMatch Match)
        {
            return DB_CURD.CreateMatch(Match);
        }

        [HttpPost]
        public RetourAPI CreateMatchAllPairing(Round Round)
        {
            List<int> Players = new();
            foreach (ViewParticipant p in DB_CURD.GetParticipantsOf(Round.IdTournament))
                if (!p.Drop)
                    Players.Add(p.IdUser);

            List<ViewScoreClassementTemporaire> Classements =
                DB_CURD.GetScoreClassementTemporairesOfTournamnent(Round.IdTournament);
            List<ViewMatch> Matches = DB_CURD.GetMatchesOf(Round.IdTournament);
            ViewTournament Tournoi = DB_CURD.GetTournament(Round.IdTournament);

            List<PairID> PairingList = AlgoPairing.Pairing(Players, Classements, Matches, Round.RoundNumber);

            return DB_CURD.CreateMatchAllParing(Round, PairingList);
        }

        [HttpPost]
        public RetourAPI EditMatch(ViewMatch Match, int P1, int P2)
        {
            return DB_CURD.EditMatch(Match, new PairID {ID1 = P1, ID2 = P2});
        }

        [HttpPost]
        public RetourAPI DeleteMatch(ViewMatch Match)
        {
            return DB_CURD.DeleteMatch(Match);
        }

        [HttpPost]
        public RetourAPI CreatePartie(ViewPartie Partie)
        {
            return DB_CURD.CreatePartie(Partie) ;
        }

        [HttpPost]
        public RetourAPI EditPartie(ViewPartie Partie)
        {
            return DB_CURD.EditPartie(Partie) ;
        }

        [HttpPost]
        public RetourAPI DeletePartie(ViewPartie Partie)
        {
            return DB_CURD.DeletePartie(Partie) ;
        }

        [HttpPost]
        public RetourAPI CreateOrUpdatePartie(ViewPartie Partie)
        {
            var p = DB_CURD.ViewPartieOfMatch(Partie.IdTournament, Partie.IdPlayer1, Partie.PartNumber,
                Partie.RoundNumber);
            if (p != null && p.IdTournament == Partie.IdTournament)
            {
                return DB_CURD.EditPartie(Partie);
            }
            else
            {
                return DB_CURD.CreatePartie(Partie);
            }
        }

        #endregion

        #region Jeu

        [HttpPost]
        public RetourAPI CreateJeu(Jeu Jeu)
        {
            return DB_CURD.AddGame(Jeu);
        }

        [HttpPost]
        public RetourAPI EditJeu(Jeu Jeu)
        {
            return DB_CURD.EditGame(Jeu);
        }

        [HttpPost]
        public RetourAPI DeleteJeu(Jeu Jeu)
        {
            return DB_CURD.DeleteGame(Jeu);
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