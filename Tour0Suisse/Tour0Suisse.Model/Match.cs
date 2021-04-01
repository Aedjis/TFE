using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Match
    {
        public Match()
        {
            Tournament = new ViewTournament();
            Player1 = new ViewParticipant();
            Player2 = new ViewParticipant();
        }
        public ViewTournament Tournament { get; set; }
        public int RoundNumber { get; set; }
        public ViewParticipant Player1 { get; set; }
        public ViewParticipant Player2 { get; set; }

    }
}
