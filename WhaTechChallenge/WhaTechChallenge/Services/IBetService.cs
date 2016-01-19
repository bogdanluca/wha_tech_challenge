using System.Collections.Generic;
using WhaTechChallenge.Models;

namespace WhaTechChallenge.Services
{
    public interface IBetService
    {
        IEnumerable<UserSettledBetHistory> GetSettledBetHistory();
        IEnumerable<UnsettledBetItem> GetUnsettledBets();
    }
}