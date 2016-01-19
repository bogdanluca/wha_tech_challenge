using System.Collections.Generic;
using System.Linq;
using WhaTechChallenge.Models;
using WhaTechChallenge.Repositories;

namespace WhaTechChallenge.Services
{
    public class BetHistoryService : IBetHistoryService
    {
        private readonly IBetHistoryRepository repository;

        public BetHistoryService(IBetHistoryRepository repository)
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

        public IEnumerable<UserUnsettledBetHistory> GetUnsettledBetHistory()
        {
            return
                repository.GetUnsettledBetHistory()
                    .GroupBy(bhi => bhi.CustomerID).OrderBy(g =>g.Key)
                    .Select(g => new UserUnsettledBetHistory(g.ToList()));
        }
    }
}