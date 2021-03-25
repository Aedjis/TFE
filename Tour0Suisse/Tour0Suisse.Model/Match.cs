using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Match
    {
       
        public ViewTournament Tournament { get; set; }
        public int RoundNumber { get; set; }
        public ViewParticipant Player1 { get; set; }
        public ViewParticipant Player2 { get; set; }

    }
}
