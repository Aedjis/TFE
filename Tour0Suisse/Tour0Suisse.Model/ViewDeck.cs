using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IViewDeck
    {
        int IdTournament { get; set; }
        string Name { get; set; }
        int IdUser { get; set; }
        string Pseudo { get; set; }
        int IdDeck { get; set; }
        string DeckList { get; set; }
        int IdGame { get; set; }
        string Game { get; set; }
    }

    public class ViewDeck : IViewDeck
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
