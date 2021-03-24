using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class ViewRound
    {
        public int IdTournament { get; set; }
        public string Name { get; set; }
        public int RoundNumber { get; set; }
        public DateTime StartRound { get; set; }
    }
}
