using System.Collections.Generic;
using NUnit.Framework;
using WhaTechChallenge.Models;

namespace WhaTechChallenge.Tests.Models
{
    [TestFixture]
    public class UnsettledBetItemSpecs
    {
        public UserSettledBetHistory CreateUserBetHistoryWithUnusualWinningRate()
        {
            var betHistoryItems = new List<SettledBetHistoryItem>
            {
                new SettledBetHistoryItem {CustomerID = 1, Stake = 10, Win = 20},
                new SettledBetHistoryItem {CustomerID = 1, Stake = 20, Win = 0},
                new SettledBetHistoryItem {CustomerID = 1, Stake = 30, Win = 40}
            };

            return new UserSettledBetHistory(betHistoryItems);
        }

        public UserSettledBetHistory CreateUserBetHistoryWithNormalWinningRate()
        {
            var betHistoryItems = new List<SettledBetHistoryItem>
            {
                new SettledBetHistoryItem {CustomerID = 1, Stake = 20, Win = 30},
                new SettledBetHistoryItem {CustomerID = 1, Stake = 20, Win = 0},
                new SettledBetHistoryItem {CustomerID = 1, Stake = 50, Win = 0},
                new SettledBetHistoryItem {CustomerID = 1, Stake = 30, Win = 40}
            };

            return new UserSettledBetHistory(betHistoryItems);
        }

        [Test]
        public void Should_have_no_risk_if_user_has_no_bet_history()
        {
            var unsettledBetItem = new UnsettledBetItem(new UnsettledBetItemDto(), null);

            var actual = unsettledBetItem.RiskType;

            Assert.That(actual, Is.EqualTo(UnsettledBetRiskType.NoRisk));
        }

        [Test]
        public void Should_have_no_risk_if_user_has_bet_history_with_normal_winning_rate()
        {
            var unsettledBetItem = new UnsettledBetItem(new UnsettledBetItemDto(),
                CreateUserBetHistoryWithNormalWinningRate());

            var actual = unsettledBetItem.RiskType;

            Assert.That(actual, Is.EqualTo(UnsettledBetRiskType.NoRisk));
        }

        [Test]
        public void Should_be_risky_if_user_has_bet_history_with_unusual_winning_rate()
        {
            var unsettledBetItem = new UnsettledBetItem(new UnsettledBetItemDto(),
                CreateUserBetHistoryWithUnusualWinningRate());

            var actual = unsettledBetItem.RiskType;

            Assert.That(actual, Is.EqualTo(UnsettledBetRiskType.Risky));
        }

        [Test]
        public void Should_be_highly_unusual_if_the_stake_is_more_than_30_times_higher_than_the_average_bet()
        {
            var unsettledBetItem = new UnsettledBetItem(new UnsettledBetItemDto { PotentialWin = 2000, Stake = 1100 },
                CreateUserBetHistoryWithNormalWinningRate());

            var actual = unsettledBetItem.RiskType;

            Assert.That(actual, Is.EqualTo(UnsettledBetRiskType.HighlyUnusual));
        }

        [Test]
        public void Should_be_unusual_if_the_stake_is_more_than_10_times_higher_than_the_average_bet()
        {
            var unsettledBetItem = new UnsettledBetItem(new UnsettledBetItemDto { PotentialWin = 800, Stake = 400 },
                CreateUserBetHistoryWithNormalWinningRate());

            var actual = unsettledBetItem.RiskType;

            Assert.That(actual, Is.EqualTo(UnsettledBetRiskType.Unusual));
        }

        [Test]
        public void Should_be_risky_if_the_potential_win_is_1000_dollars_or_more()
        {
            var unsettledBetItem = new UnsettledBetItem(new UnsettledBetItemDto { PotentialWin = 1001 },
                CreateUserBetHistoryWithNormalWinningRate());

            var actual = unsettledBetItem.RiskType;

            Assert.That(actual, Is.EqualTo(UnsettledBetRiskType.Risky));
        }
    }
}