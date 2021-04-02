using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class ViewJeu
    {
        public int IdGame { get; set; }
        [Display(Name = "Nom dujeu")]
        public string Name { get; set; }
        public bool? Deleted { get; set; }
    }
}
