using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class ViewClassementTemporaire
    {
        public int IdTournament { get; set; }
        public int IdPlayer { get; set; }
        [Display(Name = "Nombre de victoire")]
        public int Victoire { get; set; }
        [Display(Name = "Nombre de égaliter")]
        public int Egaliter { get; set; }
        [Display(Name = "Nombre de défaite")]
        public int Defaite { get; set; }
        [Display(Name = "Pseudo en jeu")]
        public string IGPseudo { get; set; }
        [Display(Name = "Nom")]
        public string Pseudo { get; set; }
    }
}
