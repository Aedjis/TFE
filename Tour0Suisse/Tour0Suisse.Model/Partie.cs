using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Partie
    {
        public int IdTournament { get; set; }
        public int RoundNumber { get; set; }
        public int IdPlayer1 { get; set; }
        public int IdPlayer2 { get; set; }
        public int PartNumber { get; set; }
        public int IdDeckPlayer1 { get; set; }
        public int IdDeckPlayer2 { get; set; }
        public byte? ResultPart { get; set; }

    }
}
