using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Round
    {
        public Round()
        {
            Match = new HashSet<Match>();
        }

        public int IdTournament { get; set; }
        public int RoundNumber { get; set; }
        public DateTime StartRound { get; set; }

    }
}
