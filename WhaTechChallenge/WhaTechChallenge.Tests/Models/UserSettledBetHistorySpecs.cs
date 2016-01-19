using System.Collections.Generic;
using NUnit.Framework;
using WhaTechChallenge.Models;

namespace WhaTechChallenge.Tests.Models
{
    [TestFixture]
    public class UserSettledBetHistorySpecs
    {
        public IList<SettledBetHistoryItem> CreateBetHistoryWithUnusualWinningRate()
        {
            return new List<SettledBetHistoryItem>
            {
                new SettledBetHistoryItem {CustomerID = 1, Stake = 10, Win = 20},
                new SettledBetHistoryItem {CustomerID = 1, Stake = 20, Win = 0},
                new SettledBetHistoryItem {CustomerID = 1, Stake = 30, Win = 40}
            };
        }

        public IList<SettledBetHistoryItem> CreateBetHistoryWithNormalWinningRate()
        {
            return new List<SettledBetHistoryItem>
            {
                new SettledBetHistoryItem {CustomerID = 1, Stake = 10, Win = 20},
                new SettledBetHistoryItem {CustomerID = 1, Stake = 20, Win = 0},
                new SettledBetHistoryItem {CustomerID = 1, Stake = 50, Win = 0},
                new SettledBetHistoryItem {CustomerID = 1, Stake = 30, Win = 40}
            };
        }

        [Test]
        public void Should_have_unusual_wining_rate_flag_set_to_false_if_winning_rate_is_lower_than_60_percent()
        {
            var userBetHistory = new UserSettledBetHistory(CreateBetHistoryWithNormalWinningRate());

            Assert.That(userBetHistory.HasUnusualWinningRate, Is.False);
        }

        [Test]
        public void Should_have_unusual_wining_rate_flag_set_to_true_if_winning_rate_is_greater_than_60_percent()
        {
            var userBetHistory = new UserSettledBetHistory(CreateBetHistoryWithUnusualWinningRate());

            Assert.That(userBetHistory.HasUnusualWinningRate, Is.True);
        }
    }
}