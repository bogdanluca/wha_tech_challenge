using System.Collections.Generic;
using WhaTechChallenge.Models;

namespace WhaTechChallenge.Repositories
{
    public interface IBetRepository
    {
        IEnumerable<SettledBetHistoryItem> GetSettledBetHistory();
        IEnumerable<UnsettledBetItemDto> GetUnsettledBets();
    }
}