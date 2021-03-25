using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Round
    {

        public int IdTournament { get; set; }
        public string Name { get; set; }
        public int RoundNumber { get; set; }
        public DateTime StartRound { get; set; }
        public IEnumerable<ViewMatch> Matches { get; set; }

    }
}
