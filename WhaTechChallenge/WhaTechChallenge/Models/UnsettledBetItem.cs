namespace WhaTechChallenge.Models
{
    public class UnsettledBetItem
    {
        private readonly UnsettledBetItemDto item;
        private readonly UserSettledBetHistory userBetHistory;

        public UnsettledBetItem(UnsettledBetItemDto item, UserSettledBetHistory userBetHistory)
        {
            this.item = item;
            this.userBetHistory = userBetHistory;
        }

        public int UserID { get { return item.CustomerID; } }
        public int EventID { get { return item.EventID; } }
        public int ParticipantID { get { return item.ParticipantID; } }
        public decimal Stake { get { return item.Stake; } }
        public int PotentialWin { get { return item.PotentialWin; } }

        public UnsettledBetRiskType RiskType
        {
            get
            {
                if (userBetHistory == null)
                    return UnsettledBetRiskType.NoRisk;

                if (IsHighlyUnusual())
                    return UnsettledBetRiskType.HighlyUnusual;

                if (IsUnusual())
                    return UnsettledBetRiskType.Unusual;

                if (IsRisky())
                    return UnsettledBetRiskType.Risky;

                return UnsettledBetRiskType.NoRisk;
            }
        }

        private bool IsRisky()
        {
            return PotentialWin >= 1000 || userBetHistory.HasUnusualWinningRate;
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