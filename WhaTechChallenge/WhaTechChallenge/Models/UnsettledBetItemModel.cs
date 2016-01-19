using WhaTechChallenge.Common;

namespace WhaTechChallenge.Models
{
    public class UnsettledBetItemModel
    {
        public int UserID { get; set; }
        public int EventID { get; set; }
        public int ParticipantID { get; set; }
        public decimal Stake { get; set; }
        public int PotentialWin { get; set; }
        public decimal AverageBet { get; set; }
        public UnsettledBetRiskType RiskType { get; set; }
    }
}