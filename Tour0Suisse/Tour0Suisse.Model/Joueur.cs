using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Joueur
    {
        public int IdTournament { get; set; }
        public int IdUser { get; set; }
        public DateTime? CheckIn { get; set; }
        public bool Drop { get; set; }

    }
}
