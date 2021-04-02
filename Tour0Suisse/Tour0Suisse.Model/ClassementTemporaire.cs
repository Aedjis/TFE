using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tour0Suisse.Model
{
    class ClassementTemporaire
    {
        [DisplayName("Id du tournoi")]
        public int IdTournament { get; set; }
        [DisplayName("Id du joueur")]
        public int IdPlayer { get; set; }
        [DisplayName("Nombre de victoire")]
        public int? Victoire { get; set; }
        [DisplayName("Nombre d'égaliter")]
        public int? Egaliter { get; set; }
        [DisplayName("Nombre de défaite")]
        public int? Defaite { get; set; }
    }
}
