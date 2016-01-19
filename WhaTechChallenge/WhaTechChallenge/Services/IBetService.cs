using System.Collections.Generic;
using WhaTechChallenge.BusinessObjects;

namespace WhaTechChallenge.Services
{
    public interface IBetService
    {
        IEnumerable<UserSettledBetHistory> GetSettledBetHistory();
        IEnumerable<RiskAssessedUnsettledBetItem> GetUnsettledBets();
    }
}