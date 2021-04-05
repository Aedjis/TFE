using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tour0Suisse.Model
{
    public interface IViewDotation
    {
        int IdTournament { get; set; }
        string Name { get; set; }
        int Place { get; set; }
        int Gain { get; set; }
    }

    public class ViewDotation : IViewDotation
    {
        public int IdTournament { get; set; }
        [Display(Name = "Tournoi")]
        public string Name { get; set; }
        [Display(Name = "Place")]
        public int Place { get; set; }
        [Display(Name = "Dotation")]
        public int Gain { get; set; }
    }
}
