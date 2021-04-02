using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tour0Suisse.Model
{
    public partial class Jeu
    {

        public int IdGame { get; set; }
        [DisplayName("Jeu")]
        public string Name { get; set; }
        public bool? Deleted { get; set; }

    }
}
