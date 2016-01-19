using System;
using System.Collections.Generic;

namespace WhaTechChallenge.Models
{
    public class UserSettledBetHistoryModel
    {
        public IList<SettledBetHistoryItemModel> Bets { get; set; }
        public int UserID { get; set; }
        public bool HasUnusualWinningRate { get; set; }
        public decimal WinRate { get; set; }
        public decimal AverageBet { get; set; }

        public string WinRateAsString
        {
            get
            {
                var winRateAsString = string.Format("{0}%", Math.Round(WinRate*100, MidpointRounding.AwayFromZero));

                if (HasUnusualWinningRate)
                    winRateAsString = string.Format("{0} (unusual)", winRateAsString);

                return winRateAsString;
            }
        }
    }
}