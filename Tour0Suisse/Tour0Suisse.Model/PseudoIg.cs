using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class PseudoIg
    {
        public int IdUser { get; set; }
        public int IdGame { get; set; }
        [Display(Name = "Jeu")]
        public string Game { get; set; }
        [Display(Name = "Pseudo")]
        public string IgPseudo { get; set; }

    }
}
