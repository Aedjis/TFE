using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IViewMatch
    {
        int RoundNumber { get; set; }
        int IdPlayer1 { get; set; }
        int IdPlayer2 { get; set; }
        int IdTournament { get; set; }
        string Player1 { get; set; }
        string Pseudo1 { get; set; }
        string Player2 { get; set; }
        string Pseudo2 { get; set; }
    }

    public class ViewMatch : IViewMatch
    {
        [Display(Name = "Round numero")]
        public int RoundNumber { get; set; }
        public int IdPlayer1 { get; set; }
        public int IdPlayer2 { get; set; }
        public int IdTournament { get; set; }
        [Display(Name = "Joueur 1")]
        public string Player1 { get; set; }
        [Display(Name = "Pseudo du joueur 1")]
        public string Pseudo1 { get; set; }
        [Display(Name = "Joueur 2")]
        public string Player2 { get; set; }
        [Display(Name = "Pseudo du joueur 2")]
        public string Pseudo2 { get; set; }
    }
}
