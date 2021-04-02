using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class Round
    {
        public Round()
        {
            Matches = new List<ViewMatch>();
        }

        public int IdTournament { get; set; }
        [Display(Name = "Tournoi")]
        public string Name { get; set; }
        [Display(Name = "Round numero")]
        public int RoundNumber { get; set; }
        [Display(Name = "Debut de la round")]
        public DateTime StartRound { get; set; }
        [Display(Name = "Liste des matchs")]
        public IEnumerable<ViewMatch> Matches { get; set; }

    }
}
