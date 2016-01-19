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

    }
}