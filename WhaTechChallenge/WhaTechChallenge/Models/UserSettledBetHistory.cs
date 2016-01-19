using System.Collections.Generic;
using System.Linq;

namespace WhaTechChallenge.Models
{
    public class UserSettledBetHistory
    {
        public UserSettledBetHistory(IEnumerable<SettledBetHistoryItem> bets)
        {
            Bets = bets ?? new List<SettledBetHistoryItem>();
        }

        public IEnumerable<SettledBetHistoryItem> Bets { get; private set; }

        public int UserID
        {
            get { return Bets.Any() ? Bets.First().CustomerID : 0; }
        } 
    }
}