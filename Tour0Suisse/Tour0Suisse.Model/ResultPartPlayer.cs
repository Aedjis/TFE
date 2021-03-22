using System;
using System.Collections.Generic;
using System.Text;

namespace Tour0Suisse.Model
{
    class ResultPartPlayer
    {
        public int IdTournament { get; set; }
        public int RoundNumber { get; set; }
        public int PartNumber { get; set; }
        public int IdPlayer { get; set; }
        public int? Resulta { get; set; }
    }
}
