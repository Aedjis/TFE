using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IViewClassementTemporaire
    {
        int IdTournament { get; set; }
        int IdPlayer { get; set; }
        int Victoire { get; set; }
        int Egaliter { get; set; }
        int Defaite { get; set; }
        string IGPseudo { get; set; }
        string Pseudo { get; set; }
    }

    public class ViewClassementTemporaire : IViewClassementTemporaire
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
