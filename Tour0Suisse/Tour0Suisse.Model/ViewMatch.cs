using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class ViewMatch
    {
        public int RoundNumber { get; set; }
        public int IdPlayer1 { get; set; }
        public int IdPlayer2 { get; set; }
        public int IdTournament { get; set; }
        public string Player1 { get; set; }
        public string Pseudo1 { get; set; }
        public string Player2 { get; set; }
        public string Pseudo2 { get; set; }
    }
}
