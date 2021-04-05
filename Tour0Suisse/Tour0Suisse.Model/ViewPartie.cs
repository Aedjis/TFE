using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IViewPartie
    {
        int IdTournament { get; set; }
        string Name { get; set; }
        int RoundNumber { get; set; }
        int PartNumber { get; set; }
        byte? ResultPart { get; set; }
        int IdPlayer1 { get; set; }
        string Player1 { get; set; }
        string IGPseudo1 { get; set; }
        int IdDeckPlayer1 { get; set; }
        string Deck1 { get; set; }
        int IdPlayer2 { get; set; }
        string Player2 { get; set; }
        string IGPseudo2 { get; set; }
        int IdDeckPlayer2 { get; set; }
        string Deck2 { get; set; }
    }

    public class ViewPartie : IViewPartie
    {
        public int IdTournament { get; set; }
        [Display(Name = " nom tournoi")]
        public string Name { get; set; }
        [Display(Name = "Round numero")]
        public int RoundNumber { get; set; }
        [Display(Name = "Partie numero")]
        public int PartNumber { get; set; }
        [Display(Name = "Gagnant")]
        public byte? ResultPart { get; set; }
        public int IdPlayer1 { get; set; }
        [Display(Name = "Joueur 1")]
        public string Player1 { get; set; }
        [Display(Name = "Pseudo joueur 1")]
        public string IGPseudo1 { get; set; }
        public int IdDeckPlayer1 { get; set; }
        [Display(Name = "Deck du joueur 1")]
        public string Deck1 { get; set; }
        public int IdPlayer2 { get; set; }
        [Display(Name = "Joueur 2")]
        public string Player2 { get; set; }
        [Display(Name = "Pseudo du joueur 2")]
        public string IGPseudo2 { get; set; }
        public int IdDeckPlayer2 { get; set; }
        [Display(Name = "deck du joueur 2")]
        public string Deck2 { get; set; }
    }
}
