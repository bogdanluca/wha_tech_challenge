﻿namespace WhaTechChallenge.BusinessObjects
{
    public class UnsettledBetItem
    {
        public int CustomerID { get; set; }
        public int EventID { get; set; }
        public int ParticipantID { get; set; }
        public decimal Stake { get; set; }
        public int PotentialWin { get; set; }
    }
}