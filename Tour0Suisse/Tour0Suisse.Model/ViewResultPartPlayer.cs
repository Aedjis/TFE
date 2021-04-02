using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class ViewResultPartPlayer
    {
        public int IdTournament { get; set; }
        [Display(Name = "Round Numero")]
        public int RoundNumber { get; set; }
        [Display(Name = "Partie numero")]
        public int PartNumber { get; set; }
        public int IdPlayer { get; set; }
        [Display(Name = "Resulta")]
        public int? Resulta { get; set; }
        [Display(Name = "Joueur")]
        public string Pseudo { get; set; }
        [Display(Name = "Pseudo en jeu")]
        public string IGPseudo { get; set; }
    }
}
