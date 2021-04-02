using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class ViewParticipant
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
