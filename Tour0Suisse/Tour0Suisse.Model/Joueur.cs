using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Tour0Suisse.Model
{
    public class Joueur : IViewParticipant
    {
        public Joueur()
        {
            User = new ViewUser();
            Tournament = new ViewTournament();

        }

        
        public ViewTournament Tournament { get; set; }
        public ViewUser User { get; set; }
        [Display(Name = "Pseudo dans le jeu")]
        public string IGPseudo { get; set; }
        [Display(Name = "Date d'inscription au tournoi")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "Date du checkIn")]
        public DateTime? CheckIn { get; set; }
        [Display(Name = "Abandon")]
        public bool Drop { get; set; }

        [Display(Name = "Liste des decks")]
        public IEnumerable<ViewDeck> Decks
        {
            get { return _decks; }
            set
            {
                if(value != null && value.Any()){ _decks = value.ToArray();}
            }
        }

        private ViewDeck[] _decks;
        public ViewDeck[] Deck
        {
            get { return _decks; }
            set { _decks = value; }
        }

        public int IdTournament
        {
            get { return Tournament.IdTournament; }
            set { Tournament.IdTournament = value; }
        }

        public string Name
        {
            get { return Tournament.Name; }
            set { Tournament.Name = value; }
        }

        public int IdUser
        {
            get { return User.IdUser; }
            set { User.IdUser = value; }
        }

        public string Pseudo
        {
            get { return User.Pseudo; }
            set { User.Pseudo = value; }
        }
    }

    
}
