using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IViewRound
    {
        int IdTournament { get; set; }
        string Name { get; set; }
        int RoundNumber { get; set; }
        DateTime? StartRound { get; set; }
        DateTime? EndRound { get; set; }
    }

    public class ViewRound : IViewRound
    {
        public int IdTournament { get; set; }
        [Display(Name = "Nom du tournoi")]
        public string Name { get; set; }
        [Display(Name = "Round numero")]
        public int RoundNumber { get; set; }
        [Display(Name = "Début de round")]
        public DateTime? StartRound { get; set; }
        [Display(Name = "Fin de round")]
        public DateTime? EndRound { get; set; }
    }
}
