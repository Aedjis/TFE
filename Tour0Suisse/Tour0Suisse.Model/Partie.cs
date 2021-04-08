using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IPartie
    {
        int IdTournament { get; set; }
        int RoundNumber { get; set; }
        int IdPlayer1 { get; set; }
        int IdPlayer2 { get; set; }
        int PartNumber { get; set; }
        int IdDeckPlayer1 { get; set; }
        int IdDeckPlayer2 { get; set; }
        byte? ResultPart { get; set; }
    }

    public class Partie : IPartie
    {
        public int IdTournament { get; set; }
        [Display(Name = "Round Numero")]
        public int RoundNumber { get; set; }
        public int IdPlayer1 { get; set; }
        public int IdPlayer2 { get; set; }
        public int PartNumber { get; set; }
        public int IdDeckPlayer1 { get; set; }
        public int IdDeckPlayer2 { get; set; }
        [Display(Name = "Resulta")]
        public byte? ResultPart { get; set; }

    }
}
