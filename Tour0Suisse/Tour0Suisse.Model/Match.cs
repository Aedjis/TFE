using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Match
    {
       
        public int IdTournament { get; set; }
        public int RoundNumber { get; set; }
        public int IdPlayerOne { get; set; }
        public int IdPlayerTwo { get; set; }

    }
}
