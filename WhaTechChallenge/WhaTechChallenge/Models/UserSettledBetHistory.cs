using System;
using System.Collections.Generic;
using System.Linq;

namespace WhaTechChallenge.Models
{
    public class UserSettledBetHistory
    {
        private const decimal UnusualWinRateThreshold = 0.6m;

        public UserSettledBetHistory(IList<SettledBetHistoryItem> bets)
        {
            Bets = bets ?? new List<SettledBetHistoryItem>();
        }

        public IList<SettledBetHistoryItem> Bets { get; private set; }

        public int UserID
        {
            get { return Bets.Any() ? Bets.First().CustomerID : 0; }
        }

        public bool HasUnusualWinningRate
        {
            get
            {
                return Bets.Any() && WinRate > UnusualWinRateThreshold;
            }
        }

        private decimal WinRate
        {
            get { return Bets.Count(bi => bi.Win > 0)/(decimal) Bets.Count; }
        }

        public string WinRateAsString
        {
            get { return string.Format("{0}%", Math.Round(WinRate * 100, MidpointRounding.AwayFromZero)); }
        }

        public decimal AverageBet
        {
            get { return Bets.Average(b => b.Stake); }
        }
    }
}