using WhaTechChallenge.BusinessObjects;
using WhaTechChallenge.Models;

namespace WhaTechChallenge
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.CreateMap<RiskAssessedUnsettledBetItem, UnsettledBetItemModel>();
            AutoMapper.Mapper.CreateMap<SettledBetHistoryItem, SettledBetHistoryItemModel>();
            AutoMapper.Mapper.CreateMap<UserSettledBetHistory, UserSettledBetHistoryModel>();
        }
    }
}