using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IViewParticipant
    {
        int IdTournament { get; set; }
        string Name { get; set; }
        int IdUser { get; set; }
        string Pseudo { get; set; }
        string IGPseudo { get; set; }
        DateTime RegisterDate { get; set; }
        DateTime? CheckIn { get; set; }
        bool Drop { get; set; }
    }

    public class ViewParticipant : IViewParticipant
    {
        public int IdTournament { get; set; }
        [Display(Name = "Tournoi")]
        public string Name { get; set; }
        public int IdUser { get; set; }
        [Display(Name = "Joueur")]
        public string Pseudo { get; set; }
        [Display(Name = "Pseudo dans le jeu")]
        public string IGPseudo { get; set; }
        [Display(Name = "Date d'inscription au tournoi")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "Date de checkin")]
        public DateTime? CheckIn { get; set; }
        [Display(Name = "Abandon")]
        public bool Drop { get; set; }
    }
}
