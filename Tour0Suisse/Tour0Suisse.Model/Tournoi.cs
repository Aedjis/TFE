using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public class Tournoi : IViewTournament
    {
        public Tournoi()
        {
            jeu = new ViewJeu();
            Participants = new List<ViewParticipant>();
            Organisateurs = new List<ViewOrga>();
            Resultas = new List<ViewResulta>();
            Classement = new List<ViewScoreClassementTemporaire>();
            Dotation = new List<ViewDotation>();
            Matchs = new List<ViewMatch>();
            Rounds = new List<ViewRound>();
        }

        public int IdGame
        {
            get => jeu.IdGame;
            set => jeu.IdGame = value;
        }
        public int IdTournament { get; set; }
        [Display(Name = "Nom du Tournoi")]
        public string Name { get; set; }
        [Display(Name = "Date du tournoi")]
        public DateTime Date { get; set; }
        [Display(Name = "Description du tournoi")]
        public string Description { get; set; }
        [Display(Name = "Nombre de deck a soumettre")]
        public int DeckListNumber { get; set; }
        [Display(Name = "Nombre maximum de joueur")]
        public int? MaxNumberPlayer { get; set; }
        [Display(Name = "Point par victoire")]
        public int Ppwin { get; set; }
        [Display(Name = "Point par egaliter")]
        public int Ppdraw { get; set; }
        [Display(Name = "Point par defaite")]
        public int Pplose { get; set; }
        [Display(Name = "Le tournoi est-il fini")]
        public bool Over { get; set; }
        [Display(Name = "Date d'annulation du tournoi")]
        public DateTime? Deleted { get; set; }
        [Display(Name = "Jeu")]
        public ViewJeu jeu { get; set; }
        [Display(Name = "Liste des participants")]
        public IEnumerable<ViewParticipant> Participants { get; set; }
        [Display(Name = "Liste des organisateur")]
        public IEnumerable<ViewOrga> Organisateurs { get; set; }
        [Display(Name = "Resulta des joueurs")]
        public IEnumerable<ViewResulta> Resultas { get; set; }
        [Display(Name = "Classement temporaire")]
        public IEnumerable<ViewScoreClassementTemporaire> Classement { get; set; }
        [Display(Name = "Liste de la dotation")]
        public IEnumerable<ViewDotation> Dotation { get; set; }
        [Display(Name = "Liste des matches")]
        public IEnumerable<ViewMatch> Matchs { get; set; }
        [Display(Name = "Liste des rondes")]
        public IEnumerable<ViewRound> Rounds { get; set; }
        [Display(Name = "Jeu")]
        public string Game { get => jeu.Name; set => jeu.Name = value; }
    }
}
