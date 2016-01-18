using System.Collections.Generic;
using WhaTechChallenge.Models;

namespace WhaTechChallenge.Repositories
{
    public interface IBetHistoryRepository
    {
        IEnumerable<SettledBetHistoryItem> GetSettledBetHistory();
        IEnumerable<UnsettledBetHistoryItem> GetUnsettledBetHistory();
    }
}