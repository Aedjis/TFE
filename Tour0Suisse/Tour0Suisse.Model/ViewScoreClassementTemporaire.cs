using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class ViewScoreClassementTemporaire
    {
        public int IdTournament { get; set; }
        public string Tournament { get; set; }
        public int IdPlayer { get; set; }
        public int? Score { get; set; }
        public int? Victoire { get; set; }
        public int? Egaliter { get; set; }
        public int? Defaite { get; set; }
        public string IGPseudo { get; set; }
        public string Pseudo { get; set; }
    }
}
