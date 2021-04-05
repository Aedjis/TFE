using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public class Match : IViewMatch

    {
    public Match()
    {
        Tournament = new ViewTournament();
        P1 = new ViewParticipant();
        P2 = new ViewParticipant();
    }

        public IViewTournament Tournament { get; set; }
        [Display(Name = "Round Numero")] public int RoundNumber { get; set; }
        public IViewParticipant P1 { get; set; }
        public IViewParticipant P2 { get; set; }
        public int IdPlayer1 { get => P1.IdUser; set => P1.IdUser = value; }
        public int IdPlayer2 { get => P2.IdUser; set => P2.IdUser = value; }
        public int IdTournament { get => Tournament.IdTournament; set => Tournament.IdTournament = value; }
        public string Pseudo1 { get=> P1.IGPseudo; set => P1.IGPseudo = value ; }
        public string Pseudo2 { get => P2.IGPseudo; set => P2.IGPseudo = value; }
        public string Player1 { get => P1.Pseudo; set => P1.Pseudo = value; }
        public string Player2 { get => P2.Pseudo; set => P2.Pseudo = value; }
    }
}
