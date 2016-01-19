using System.Collections.Generic;
using System.Linq;

namespace WhaTechChallenge.BusinessObjects
{
    public class UserSettledBetHistory
    {
        private const decimal UnusualWinRateThreshold = 0.6m;

        public UserSettledBetHistory(IList<SettledBetHistoryItem> bets)
        {
            Bets = bets ?? new List<SettledBetHistoryItem>();
        }

        public IList<SettledBetHistoryItem> Bets { get; }

        public int UserID
        {
            get { return Bets.Any() ? Bets.First().CustomerID : 0; }
        }

        public bool HasUnusualWinningRate
        {
            get { return Bets.Any() && WinRate > UnusualWinRateThreshold; }
        }

        public decimal WinRate
        {
            get { return Bets.Count(bi => bi.Win > 0)/(decimal) Bets.Count; }
        }

        public decimal AverageBet
        {
            get { return Bets.Average(b => b.Stake); }
        }
    }
}