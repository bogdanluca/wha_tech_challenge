using System.Collections.Generic;
using System.Linq;

namespace WhaTechChallenge.Models
{
    public class UserUnsettledBetHistory
    {
        public UserUnsettledBetHistory(IEnumerable<UnsettledBetHistoryItem> bets)
        {
            Bets = bets ?? new List<UnsettledBetHistoryItem>();
        }

        public IEnumerable<UnsettledBetHistoryItem> Bets { get; private set; }

        public int UserID
        {
            get { return Bets.Any() ? Bets.First().CustomerID : 0; }
        }
    }
}