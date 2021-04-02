using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tour0Suisse.Model
{
    public partial class Dotation
    {
        public int IdTournament { get; set; }
        [DisplayName("Top")]
        public int Place { get; set; }
        [DisplayName("Gain pour la place")]
        public int Gain { get; set; }
    }
}
