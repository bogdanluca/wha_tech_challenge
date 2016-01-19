using System;
using WhaTechChallenge.Common;

namespace WhaTechChallenge.BusinessObjects
{
    public class RiskAssessedUnsettledBetItem
    {
        private readonly UnsettledBetItem item;
        private readonly UserSettledBetHistory userBetHistory;

        public RiskAssessedUnsettledBetItem(UnsettledBetItem item, UserSettledBetHistory userBetHistory)
        {
            this.item = item;
            this.userBetHistory = userBetHistory;
        }

        public int UserID { get { return item.CustomerID; } }
        public int EventID { get { return item.EventID; } }
        public int ParticipantID { get { return item.ParticipantID; } }
        public decimal Stake { get { return item.Stake; } }
        public int PotentialWin { get { return item.PotentialWin; } }

        public decimal AverageBet
        {
            get
            {
                return userBetHistory != null
                    ? Math.Round(userBetHistory.AverageBet, MidpointRounding.AwayFromZero)
                    : 0;
            }
        }

        public UnsettledBetRiskType RiskType
        {
            get
            {
                if (userBetHistory == null)
                    return UnsettledBetRiskType.NoRisk;

                if (userBetHistory.HasUnusualWinningRate)
                    return UnsettledBetRiskType.Risky;

                if (IsHighlyUnusual())
                    return UnsettledBetRiskType.HighlyUnusual;

                if (IsUnusual())
                    return UnsettledBetRiskType.Unusual;

                if(PotentialWin >= 1000)
                    return UnsettledBetRiskType.Risky;

                return UnsettledBetRiskType.NoRisk;
            }
        }

        private bool IsHighlyUnusual()
        {
            return Stake > userBetHistory.AverageBet * 30;
        }

        private bool IsUnusual()
        {
            return Stake > userBetHistory.AverageBet * 10;
        }
    }
}