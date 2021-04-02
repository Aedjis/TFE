using System;
using System.Collections.Generic;
using  System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public partial class ViewTournament
    {
        public int IdTournament { get; set; }
        public int IdGame { get; set; }
        [Display(Name = "Nom du tournoi")]
        public string Name { get; set; }
        [Display(Name = "Jeu")]
        public string Game { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Date du tournoi")]
        public DateTime Date { get; set; }
        [Display(Name = "Nombre maximum de joueur")]
        public int? MaxNumberPlayer { get; set; }
        [Display(Name = "Nombre de deck a soumettre")]
        public int DeckListNumber { get; set; }
        [Display(Name = "Point par victoire")]
        public int Ppwin { get; set; }
        [Display(Name = "Point par egalité")]
        public int Ppdraw { get; set; }
        [Display(Name = "Point par defaite")]
        public int Pplose { get; set; }
        [Display(Name = "Date d'annulation du tournoi")]
        public DateTime? Deleted { get; set; }
        [Display(Name = "Le tournoi est fini")]
        public bool Over { get; set; }
    }
}
