using System.Collections.Generic;
using System.Linq;
using WhaTechChallenge.Models;
using WhaTechChallenge.Repositories;

namespace WhaTechChallenge.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository repository;

        public BetService(IBetRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<UserSettledBetHistory> GetSettledBetHistory()
        {
            return
                repository.GetSettledBetHistory()
                    .GroupBy(bhi => bhi.CustomerID).OrderBy(g => g.Key)
                    .Select(g => new UserSettledBetHistory(g.ToList()));
        }

        public IEnumerable<UnsettledBetItem> GetUnsettledBets()
        {
            var betHistory = GetSettledBetHistory();

            return repository.GetUnsettledBets()
                .Select(item =>
                    new UnsettledBetItem(item, betHistory.FirstOrDefault(bh => bh.UserID == item.CustomerID)));
        }
    }
}