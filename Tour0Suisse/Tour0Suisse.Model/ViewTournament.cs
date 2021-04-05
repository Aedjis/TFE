using System;
using System.Collections.Generic;
using  System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public interface IViewTournament
    {
        int IdTournament { get; set; }
        int IdGame { get; set; }
        string Name { get; set; }
        string Game { get; set; }
        string Description { get; set; }
        DateTime Date { get; set; }
        int? MaxNumberPlayer { get; set; }
        int DeckListNumber { get; set; }
        int Ppwin { get; set; }
        int Ppdraw { get; set; }
        int Pplose { get; set; }
        DateTime? Deleted { get; set; }
        bool Over { get; set; }
    }

    public class ViewTournament : IViewTournament
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
