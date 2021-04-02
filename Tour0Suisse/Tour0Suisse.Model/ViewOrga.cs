using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class ViewOrga
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
