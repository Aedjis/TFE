using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tour0Suisse.Model
{
    public class Dotation : IViewDotation
    {
        public IViewTournament Tournament { get; set; }
        [DisplayName("Top")]
        public int Place { get; set; }
        [DisplayName("Gain pour la place")]
        public int Gain { get; set; }
        public string Name { get => Tournament.Name; set => Tournament.Name = value; }
        public int IdTournament { get => Tournament.IdTournament; set => Tournament.IdTournament = value; }
    }
}
