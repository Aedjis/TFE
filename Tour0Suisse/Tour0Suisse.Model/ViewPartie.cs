using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class ViewPartie
    {
        public int IdTournament { get; set; }
        public string Name { get; set; }
        public int RoundNumber { get; set; }
        public int PartNumber { get; set; }
        public byte? ResultPart { get; set; }
        public int IdPlayerOne { get; set; }
        public string PlayerOne { get; set; }
        public string IGPseudoOne { get; set; }
        public int IdDeckPlayerOne { get; set; }
        public string DeckOne { get; set; }
        public int IdPlayerTwo { get; set; }
        public string PlayerTwo { get; set; }
        public string IGPseudoTwo { get; set; }
        public int IdDeckPlayerTwo { get; set; }
        public string DeckTwo { get; set; }
    }
}
