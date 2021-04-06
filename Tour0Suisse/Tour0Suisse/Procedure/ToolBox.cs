using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour0Suisse.Model;

namespace Tour0Suisse.Web.Procedure
{
    public static class ToolBox
    {
        public static Round CreateRoundFromView(this ViewRound View, IEnumerable<ViewMatch> ListMatches)
        {
            return new Round
            {
                EndRound = View.EndRound,
                IdTournament = View.IdTournament,
                Matches = ListMatches.Where(m => m.RoundNumber == View.RoundNumber && m.IdTournament == View.IdTournament),
                Name = View.Name,
                RoundNumber = View.RoundNumber,
                StartRound = View.StartRound
            };
        }
    }
}
