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
        public int IdPlayer1 { get; set; }
        public string Player1 { get; set; }
        public string IGPseudo1 { get; set; }
        public int IdDeckPlayer1 { get; set; }
        public string Deck1 { get; set; }
        public int IdPlayer2 { get; set; }
        public string Player2 { get; set; }
        public string IGPseudo2 { get; set; }
        public int IdDeckPlayer2 { get; set; }
        public string Deck2 { get; set; }
    }
}
