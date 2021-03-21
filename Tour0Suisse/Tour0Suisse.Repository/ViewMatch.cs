using System;
using System.Collections.Generic;

namespace Tour0Suisse.Repository
{
    public partial class ViewMatch
    {
        public int RoundNumber { get; set; }
        public int IdPlayerOne { get; set; }
        public int IdPlayerTwo { get; set; }
        public int IdTournament { get; set; }
    }
}
