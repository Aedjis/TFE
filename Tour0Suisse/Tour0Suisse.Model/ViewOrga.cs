using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IViewOrga
    {
        int IdTournament { get; set; }
        string Name { get; set; }
        int IdUser { get; set; }
        string Pseudo { get; set; }
        int? Level { get; set; }
    }

    public class ViewOrga : IViewOrga
    {
        public int IdTournament { get; set; }
        [Display(Name = "Tournoi")]
        public string Name { get; set; }
        public int IdUser { get; set; }
        [Display(Name = "Nom")]
        public string Pseudo { get; set; }
        [Display(Name = "Niveau d'acreditation")]
        public int? Level { get; set; }
    }
}
