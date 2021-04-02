using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class Resultat
    {
        public int IdTournament { get; set; }
        public int IdUser { get; set; }
        [Display(Name = "Place")]
        public int Rank { get; set; }
        [Display(Name = "Gain reçu")]
        public int Gain { get; set; }
        [Display(Name = "Score")]
        public int Score { get; set; }
        [Display(Name = "Valeur du Tiebreaker")]
        public int TieBreaker { get; set; }
        [Display(Name = "Valeur du Tiebreaker par arbitrage")]
        public int? AdditionalTieBreaker { get; set; }
        [Display(Name = "Regle du départage par arbitrage")]
        public string AdditionalTieBreakerRules { get; set; }

    }
}
