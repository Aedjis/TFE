using System;
using System.Collections.Generic;

namespace Tour0Suisse.Repository
{
    public partial class ViewParticipant
    {
        public int IdTournament { get; set; }
        public string Name { get; set; }
        public int IdUser { get; set; }
        public string Pseudo { get; set; }
        public string IGPseudo { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? CheckIn { get; set; }
        public bool Drop { get; set; }
    }
}
