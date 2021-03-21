using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Partie
    {
        public int IdTournament { get; set; }
        public int RoundNumber { get; set; }
        public int IdPlayerOne { get; set; }
        public int IdPlayerTwo { get; set; }
        public int PartNumber { get; set; }
        public int IdDeckPlayerOne { get; set; }
        public int IdDeckPlayerTwo { get; set; }
        public byte? ResultPart { get; set; }

    }
}
