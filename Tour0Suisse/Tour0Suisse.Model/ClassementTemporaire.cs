using System;
using System.Collections.Generic;
using System.Text;

namespace Tour0Suisse.Model
{
    class ClassementTemporaire
    {
        public int IdTournament { get; set; }
        public int IdPlayer { get; set; }
        public int? Victoire { get; set; }
        public int? Egaliter { get; set; }
        public int? Defaite { get; set; }
    }
}
