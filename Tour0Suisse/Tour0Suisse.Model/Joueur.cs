using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Joueur
    {


        public int IdTournament { get; set; }
        public ViewUser User { get; set; }
        public string IGPseudo { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? CheckIn { get; set; }
        public bool Drop { get; set; }
        public IEnumerable<ViewDeck> Decks { get; set; }

    }
}
