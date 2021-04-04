using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Tour0Suisse.Model
{
    public partial class Joueur
    {
        public Joueur()
        {
            User = new ViewUser();
            //_decks = new ViewDeck[10]
            //{
            //    new ViewDeck(), new ViewDeck(), new ViewDeck(), new ViewDeck(), new ViewDeck(), new ViewDeck(),
            //    new ViewDeck(), new ViewDeck(), new ViewDeck(), new ViewDeck()
            //};
        }

        
        public int IdTournament { get; set; }
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
            get
            {
                return _decks; //.Where(d=>d!=null && string.IsNullOrEmpty(d.DeckList));
            }
            set
            {
                _decks = value.ToArray(); //value.Concat(new ViewDeck[10] { new ViewDeck(), new ViewDeck(), new ViewDeck(), new ViewDeck(), new ViewDeck(), new ViewDeck(), new ViewDeck(), new ViewDeck(), new ViewDeck(), new ViewDeck() }).Take(10).ToArray();
            }
        }

        private ViewDeck[] _decks;
        public ViewDeck[] Deck 
        {
            get
            {
                return _decks;
            }
            set
            {
                _decks = value;
            }
        }
    }

    
}
