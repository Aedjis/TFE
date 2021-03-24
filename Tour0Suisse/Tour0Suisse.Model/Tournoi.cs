using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Tournoi
    {

        public int IdTournament { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Desciption { get; set; }
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

    }
}
