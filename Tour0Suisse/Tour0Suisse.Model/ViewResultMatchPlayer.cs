using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IViewResultMatchPlayer
    {
        int IdTournament { get; set; }
        int RoundNumber { get; set; }
        int IdPlayer { get; set; }
        int? Resulta { get; set; }
        string Pseudo { get; set; }
        string IGPseudo { get; set; }
    }

    public class ViewResultMatchPlayer : IViewResultMatchPlayer
    {
        public int IdTournament { get; set; }
        [Display(Name = "Round numero")]
        public int RoundNumber { get; set; }
        public int IdPlayer { get; set; }
        [Display(Name = "Resulta")]
        public int? Resulta { get; set; }
        [Display(Name = "Joueur")]
        public string Pseudo { get; set; }
        [Display(Name = "Pseudo en jeu")]
        public string IGPseudo { get; set; }
    }
}
