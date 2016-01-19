using System.Collections.Generic;
using WhaTechChallenge.BusinessObjects;

namespace WhaTechChallenge.Repositories
{
    public interface IBetRepository
    {
        IEnumerable<SettledBetHistoryItem> GetSettledBetHistory();
        IEnumerable<UnsettledBetItem> GetUnsettledBets();
    }
}