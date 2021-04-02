using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class ViewMatch
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
