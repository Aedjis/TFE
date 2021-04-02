using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class ViewScoreClassementTemporaire
    {
        public int IdTournament { get; set; }
        [Display(Name = "Nom du tournoi")]
        public string Tournament { get; set; }
        public int IdPlayer { get; set; }
        [Display(Name = "Score")]
        public int? Score { get; set; }
        [Display(Name = "Victoire")]
        public int? Victoire { get; set; }
        [Display(Name = "Egaliter")]
        public int? Egaliter { get; set; }
        [Display(Name = "Défaite")]
        public int? Defaite { get; set; }
        [Display(Name = "Pseudo en jeu")]
        public string IGPseudo { get; set; }
        [Display(Name = "Joueur")]
        public string Pseudo { get; set; }
    }
}
