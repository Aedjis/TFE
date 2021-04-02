using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Round Numero")]
        public int RoundNumber { get; set; }
        public ViewParticipant Player1 { get; set; }
        public ViewParticipant Player2 { get; set; }

    }
}
