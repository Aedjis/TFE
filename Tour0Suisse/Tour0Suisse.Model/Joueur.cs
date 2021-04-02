using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class Joueur
    {
        public Joueur()
        {
            User = new ViewUser();
            Decks = new List<ViewDeck>();
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
        public IEnumerable<ViewDeck> Decks { get; set; }

    }
}
