using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class ViewDeck
    {
        public int IdTournament { get; set; }
        [Display(Name = "Tournoi")]
        public string Name { get; set; }
        public int IdUser { get; set; }
        [Display(Name = "Utilisateur")]
        public string Pseudo { get; set; }
        public int IdDeck { get; set; }
        [Display(Name = "liste du deck")]
        public string DeckList { get; set; }
        public int IdGame { get; set; }
        [Display(Name = "Jeu")]
        public string Game { get; set; }
    }
}
