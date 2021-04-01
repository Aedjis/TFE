﻿using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Tournoi
    {
        public Tournoi()
        {
            jeu = new ViewJeu();
            Participants = new List<ViewParticipant>();
            Organisateurs = new List<ViewOrga>();
            Resultas = new List<ViewResulta>();
            Classement = new List<ViewScoreClassementTemporaire>();
            Dotation = new List<ViewDotation>();
            Matchs = new List<Match>();
        }

        public int IdGame
        {
            get => jeu.IdGame;
            set => jeu.IdGame = value;
        }
        public int IdTournament { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int DeckListNumber { get; set; }
        public int? MaxNumberPlayer { get; set; }
        public int Ppwin { get; set; }
        public int Ppdraw { get; set; }
        public int Pplose { get; set; }
        public bool Over { get; set; }
        public DateTime? Deleted { get; set; }
        public ViewJeu jeu { get; set; }
        public IEnumerable<ViewParticipant> Participants { get; set; }
        public IEnumerable<ViewOrga> Organisateurs { get; set; }
        public IEnumerable<ViewResulta> Resultas { get; set; }
        public IEnumerable<ViewScoreClassementTemporaire> Classement { get; set; }
        public IEnumerable<ViewDotation> Dotation { get; set; }
        public IEnumerable<Match> Matchs { get; set; }

    }
}
