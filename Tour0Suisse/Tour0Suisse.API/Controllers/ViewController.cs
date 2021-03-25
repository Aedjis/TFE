﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Tour0Suisse.Model;
using Tour0Suisse.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tour0Suisse.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ViewController : ControllerBase
    {
        static private DBTour0SuisseLINQ DB_CURD;

        static ViewController()
        {
            string ConnectionString =
                "Server=DESKTOP-BNVQBMF;Database=Tour0Suisse;user id=API_User;password=1234@Test;";

            DB_CURD = new DBTour0SuisseLINQ(ConnectionString);
        }

        // GET: api/<ViewController>
        [HttpGet]
        public IEnumerable<ViewUser> GetUsers()
        {
            return DB_CURD.ViewUsers().Where(u=>u.Deleted == null);
        }

        // GET api/<ViewController>/5
        [HttpGet]
        public Utilisateur GetUser([FromQuery] int id)
        {
            Utilisateur Retour = null;

            ViewUser MyUser = DB_CURD.GetUser(id);
            if (MyUser != null)
            {
                Retour = new Utilisateur
                {
                    IdUser =  MyUser.IdUser,
                    Pseudo = MyUser.Pseudo,
                    Email = MyUser.Email,
                    Organizer = MyUser.Organizer,
                    Deleted = MyUser.Deleted,
                    PseudoIgs = DB_CURD.GetPseudosUser(id)
                };
            }


            return Retour;
        }

        // GET: api/<ViewController>
        [HttpGet]
        public IEnumerable<ViewTournament> GetTournaments()
        {
            List<ViewTournament> Retour = new List<ViewTournament>();
            Retour.Clear();

            Retour = DB_CURD.ViewTournaments();

            return Retour;
        }

        // GET api/<ViewController>/5
        [HttpGet]
        public Tournoi GetTournament([FromQuery] int id)
        {
            var t = DB_CURD.GetTournament(id);

            Tournoi retour = new Tournoi
            {
                IdTournament = t.IdTournament,
                Name = t.Name,
                Date = t.Date,
                Desciption = t.Name,
                jeu = DB_CURD.GetJeu(t.IdGame),
                Participants = DB_CURD.GetParticipantsOf(t.IdTournament),
                Organisateurs = DB_CURD.GetOrgasOf(t.IdTournament),
                DeckListNumber = t.DeckListNumber,
                MaxNumberPlayer = t.MaxNumberPlayer,
                Ppwin = t.Ppwin,
                Ppdraw = t.Ppdraw,
                Pplose = t.Pplose,
                Over = t.Over,
                Deleted = t.Deleted
            };
            if (retour.Over)
            {
                retour.Resultas = DB_CURD.GetResultasOfTournament(retour.IdTournament);
            }
            else if(retour.Deleted==null)
            {
                var c = DB_CURD.GetScoreClassementTemporairesOfTournamnent(retour.IdTournament);
                retour.Classement = c.Any() ? c : null;
            }

            return retour;
        }


        [HttpGet]
        public IEnumerable<ViewJeu> GetJeus()
        {
            return DB_CURD.ViewJeus();
        }


        [HttpGet]
        public ViewJeu GetJeu([FromQuery] int id)
        {
            return DB_CURD.GetJeu(id);
        }


        //getresulta en attente pour le moment (sans doute inutile a voir)


        [HttpGet]
        public IEnumerable<ViewMatch> GetMatchs()
        {
            return DB_CURD.ViewMatches();
        }

        [HttpGet]
        public IEnumerable<ViewMatch> GetMatchsOfTournamentForRound([FromQuery]int IdTournoi, [FromQuery] int RoundNumber = -1)
        {
            return DB_CURD.GetMatchesOfTheRound(IdTournoi, RoundNumber);
        }


        [HttpGet]
        public Match GetMatchOfPlayerForTournamentForRound([FromQuery] int IdTournoi, [FromQuery] int IdPlayer, [FromQuery] int RoundNumber = -1)
        {
            var m = DB_CURD.GetMatcheForPlayerOfTheRound(IdTournoi, IdPlayer, RoundNumber);

            Match retour = new Match
            {
                Tournament = DB_CURD.GetTournament(m.IdTournament),
                RoundNumber = m.RoundNumber,
                Player1 = DB_CURD.GetParticipant(m.IdPlayer1, m.IdTournament),
                Player2 = DB_CURD.GetParticipant(m.IdPlayer2, m.IdTournament)
            };

            return retour;
        }


        [HttpGet]
        public IEnumerable<ViewDeck> GetParticipantsOf([FromQuery] int Idtournoi)
        {
            return DB_CURD.GetDecksOfTournament(Idtournoi);
        }


        [HttpGet]
        public Joueur GetParticipant([FromQuery] int Idtournoi, [FromQuery] int IdPlayer)
        {
            ViewParticipant j = DB_CURD.GetParticipant(IdPlayer, Idtournoi);

            Joueur retour = new Joueur
            {
                IdTournament = j.IdTournament,
                User = DB_CURD.GetUser(j.IdUser),
                IGPseudo = j.IGPseudo,
                RegisterDate = j.RegisterDate,
                CheckIn = j.CheckIn,
                Drop = j.Drop,
                Decks = DB_CURD.GetDecksOfParticipant(j.IdTournament, j.IdUser)
            };

            return retour;
        }

        [HttpGet]
        public IEnumerable<ViewDeck> GetDeckOfPlayer([FromQuery] int IdTournoi, [FromQuery] int IdUser)
        {
            return DB_CURD.GetDecksOfParticipant(IdTournoi, IdUser);
        }

        [HttpGet]
        public IEnumerable<ViewPartie> GetPartiesOfMatch([FromQuery] int IdTournoi, [FromQuery] int IdPlayer, [FromQuery] int RoundNumber = -1)
        {
            return DB_CURD.ViewPartiesOfMatch(IdTournoi, IdPlayer, RoundNumber) ;
        }

        [HttpGet]
        public ViewPartie GetPartieOfMatch([FromQuery] int IdTournoi, [FromQuery] int IdPlayer, [FromQuery] int PartNumber = -1, [FromQuery] int RoundNumber = -1)
        {
            return DB_CURD.ViewPartieOfMatch(IdTournoi, IdPlayer, PartNumber, RoundNumber);
        }


        [HttpGet]
        public IEnumerable<ViewRound> GetRoundsOfTournament([FromQuery] int IdTournoi)
        {
            return DB_CURD.GetRoundsOf(IdTournoi);
        }


        [HttpGet]
        public Round GetRoundOfTournament([FromQuery] int IdTournoi, [FromQuery] int RoundNumber)
        {
            var r =  DB_CURD.GetRoundOf(IdTournoi, RoundNumber);

            Round retour = new Round
            {
                IdTournament = r.IdTournament,
                Name = r.Name,
                RoundNumber = r.RoundNumber,
                StartRound = r.StartRound,
                Matches = DB_CURD.GetMatchesOfTheRound(r.IdTournament, r.RoundNumber)
            };

            return retour;
        }
        //// POST api/<ViewController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ViewController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ViewController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
