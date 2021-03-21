using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Resultat
    {
        public int IdTournament { get; set; }
        public int IdUser { get; set; }
        public int Rank { get; set; }
        public int Score { get; set; }
        public int TieBreaker { get; set; }
        public int? AdditionalTieBreaker { get; set; }
        public string AdditionalTieBreakerRules { get; set; }

    }
}
