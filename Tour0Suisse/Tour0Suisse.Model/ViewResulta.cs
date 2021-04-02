using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class ViewResulta
    {
        public int IdTournament { get; set; }
        [Display(Name = "Nom du tournoi")]
        public string Name { get; set; }
        public int IdUser { get; set; }
        [Display(Name = "Joueur")]
        public string Pseudo { get; set; }
        [Display(Name = "Pseudo dans le jeu")]
        public string IGPseudo { get; set; }
        [Display(Name = "Place")]
        public int Rank { get; set; }
        [Display(Name = "Gain")]
        public int Gain { get; set; }
        [Display(Name = "Score")]
        public int Score { get; set; }
        [Display(Name = "Score du tieBreaker")]
        public int TieBreaker { get; set; }
        [Display(Name = "Score du tiebreaker par arbitrage")]
        public int? AdditionalTieBreaker { get; set; }
        [Display(Name = "Regle du tiebreaker pas arbitrage")]
        public string AdditionalTieBreakerRules { get; set; }
    }
}
