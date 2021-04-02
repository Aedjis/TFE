using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class Organisateur
    {
        public Organisateur()
        {
            User = new ViewUser();
        }
        public int IdTournament { get; set; }
        public ViewUser User { get; set; }
        [Display(Name = "Niveau de compétance")]
        public int? Level { get; set; }

    }
}
