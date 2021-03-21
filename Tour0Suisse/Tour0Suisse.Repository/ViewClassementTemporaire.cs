using System;
using System.Collections.Generic;

namespace Tour0Suisse.Repository
{
    public partial class ViewClassementTemporaire
    {
        public int IdTournament { get; set; }
        public int IdPlayer { get; set; }
        public int? Victoire { get; set; }
        public int? Egaliter { get; set; }
        public int? Defaite { get; set; }
    }
}
