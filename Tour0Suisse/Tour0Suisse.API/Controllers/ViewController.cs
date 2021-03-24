using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
        public Utilisateur GetUser(int id)
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
        [HttpGet("{id}")]
        public Tournoi GetTournament(int id)
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


        [HttpGet("{id}")]
        public ViewJeu GetJeu(int id)
        {
            return DB_CURD.GetJeu(id);
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
