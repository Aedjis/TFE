using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class ViewRound
    {
        public int IdTournament { get; set; }
        [Display(Name = "Nom du tournoi")]
        public string Name { get; set; }
        [Display(Name = "Round numero")]
        public int RoundNumber { get; set; }
        [Display(Name = "Début de round")]
        public DateTime StartRound { get; set; }
    }
}
