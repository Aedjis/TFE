using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IViewPseudo
    {
        int IdUser { get; set; }
        int IdGame { get; set; }
        string Game { get; set; }
        string IgPseudo { get; set; }
    }

    public class ViewPseudo : IViewPseudo
    {
        public int IdUser { get; set; }
        public int IdGame { get; set; }
        [Display(Name = "Jeu")]
        public string Game { get; set; }
        [Display(Name = "Pseudo dans le jeu")]
        public string IgPseudo { get; set; }
    }
}
