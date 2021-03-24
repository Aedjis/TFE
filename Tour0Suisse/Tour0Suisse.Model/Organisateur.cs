using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Organisateur
    {
        public int IdTournament { get; set; }
        public ViewUser User { get; set; }
        public int? Level { get; set; }

    }
}
