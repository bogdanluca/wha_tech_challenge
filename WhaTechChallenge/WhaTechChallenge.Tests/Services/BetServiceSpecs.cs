using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using WhaTechChallenge.BusinessObjects;
using WhaTechChallenge.Repositories;
using WhaTechChallenge.Services;

namespace WhaTechChallenge.Tests.Services
{
    [TestFixture]
    public class BetServiceSpecs
    {
        [SetUp]
        public void Setup()
        {
            repository = A.Fake<IBetRepository>();
        }

        private IBetRepository repository;

        private BetService CreateSUT()
        {
            return new BetService(repository);
        }

        private IEnumerable<SettledBetHistoryItem> CreateSettledBetHistory()
        {
            return new List<SettledBetHistoryItem>
            {
                new SettledBetHistoryItem {CustomerID = 2, Stake = 10, Win = 20},
                new SettledBetHistoryItem {CustomerID = 1, Stake = 20, Win = 30},
                new SettledBetHistoryItem {CustomerID = 2, Stake = 30, Win = 40}
            };
        }

        [Test]
        public void Should_get_settled_history_grouped_by_UserID()
        {
            var settledBetHistory = CreateSettledBetHistory().ToList();
            A.CallTo(() => repository.GetSettledBetHistory()).Returns(settledBetHistory);

            var actual = CreateSUT().GetSettledBetHistory().ToList();

            var betHistoryForUser1 = actual.Single(ubh => ubh.UserID == 1);
            var betHistoryForUser2 = actual.Single(ubh => ubh.UserID == 2);
            Assert.That(actual.Count, Is.EqualTo(2));
            CollectionAssert.AreEquivalent(betHistoryForUser1.Bets, settledBetHistory.Where(sbh => sbh.CustomerID == 1));
            CollectionAssert.AreEquivalent(betHistoryForUser2.Bets, settledBetHistory.Where(sbh => sbh.CustomerID == 2));
        }

        [Test]
        public void Should_get_settled_history_sorted_by_UserID()
        {
            A.CallTo(() => repository.GetSettledBetHistory()).Returns(CreateSettledBetHistory());

            var actual = CreateSUT().GetSettledBetHistory().ToList();

            Assert.That(actual[0].UserID, Is.EqualTo(1));
            Assert.That(actual[1].UserID, Is.EqualTo(2));
        }
    }
}