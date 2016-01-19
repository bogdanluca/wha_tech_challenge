using System.Collections.Generic;
using WhaTechChallenge.Models;

namespace WhaTechChallenge.Services
{
    public interface IBetHistoryService
    {
        IEnumerable<UserSettledBetHistory> GetSettledBetHistory();
        IEnumerable<UserUnsettledBetHistory> GetUnsettledBetHistory();
    }
}