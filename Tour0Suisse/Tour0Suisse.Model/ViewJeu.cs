using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IViewJeu
    {
        int IdGame { get; set; }
        string Name { get; set; }
        bool? Deleted { get; set; }
    }

    public class ViewJeu : IViewJeu
    {
        public ViewJeu()
        {
            Name = "";
        }

        public int IdGame { get; set; }
        [Display(Name = "Nom dujeu")]
        public string Name { get; set; }
        public bool? Deleted { get; set; }
    }
}
