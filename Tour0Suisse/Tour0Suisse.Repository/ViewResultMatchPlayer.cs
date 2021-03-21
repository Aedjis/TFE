using System;
using System.Collections.Generic;

namespace Tour0Suisse.Repository
{
    public partial class ViewResultMatchPlayer
    {
        public int IdTournament { get; set; }
        public int RoundNumber { get; set; }
        public int IdPlayer { get; set; }
        public int? Resulta { get; set; }
    }
}
