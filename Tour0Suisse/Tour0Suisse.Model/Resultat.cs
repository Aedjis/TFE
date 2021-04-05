using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public class Resultat : IViewResulta
    {
        public Resultat()
        {
            Tournament = new ViewTournament();
            User = new ViewUser();
        }

        public IViewTournament Tournament { get; set; }
        public IViewUser User { get; set; }
        [Display(Name = "Place")]
        public int Rank { get; set; }
        [Display(Name = "Gain reçu")]
        public int Gain { get; set; }
        [Display(Name = "Score")]
        public int Score { get; set; }
        [Display(Name = "Valeur du Tiebreaker")]
        public int TieBreaker { get; set; }
        [Display(Name = "Valeur du Tiebreaker par arbitrage")]
        public int? AdditionalTieBreaker { get; set; }
        [Display(Name = "Regle du départage par arbitrage")]
        public string AdditionalTieBreakerRules { get; set; }
        public int IdTournament { get => Tournament.IdTournament; set => Tournament.IdTournament = value; }
        public string Name { get => Tournament.Name; set => Tournament.Name =value; }
        public int IdUser { get => User.IdUser; set => User.IdUser = value; }
        public string Pseudo { get => User.Pseudo; set => User.Pseudo = value; }
        public string IGPseudo { get ; set ; }
    }
}
