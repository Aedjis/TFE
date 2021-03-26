using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class ViewResulta
    {
        public int IdTournament { get; set; }
        public string Name { get; set; }
        public int IdUser { get; set; }
        public string Pseudo { get; set; }
        public string IGPseudo { get; set; }
        public int Rank { get; set; }
        public int Gain { get; set; }
        public int Score { get; set; }
        public int TieBreaker { get; set; }
        public int? AdditionalTieBreaker { get; set; }
        public string AdditionalTieBreakerRules { get; set; }
    }
}
