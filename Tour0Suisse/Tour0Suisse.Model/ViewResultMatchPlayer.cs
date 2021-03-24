using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class ViewResultMatchPlayer
    {
        public int IdTournament { get; set; }
        public int RoundNumber { get; set; }
        public int IdPlayer { get; set; }
        public int? Resulta { get; set; }
        public string Pseudo { get; set; }
        public string IGPseudo { get; set; }
    }
}
