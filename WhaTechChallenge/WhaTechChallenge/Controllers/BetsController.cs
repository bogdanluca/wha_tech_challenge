using System.Collections.Generic;
using System.Web.Mvc;
using WhaTechChallenge.BusinessObjects;
using WhaTechChallenge.Mapper;
using WhaTechChallenge.Models;
using WhaTechChallenge.Services;

namespace WhaTechChallenge.Controllers
{
    public class BetsController : Controller
    {
        private readonly IBetService betService;
        private readonly IMapper mapper;

        public BetsController(IBetService betService, IMapper mapper)
        {
            this.betService = betService;
            this.mapper = mapper;
        }

        public ActionResult Settled()
        {
            var settledBetHistoryModel =
                mapper.Map<IEnumerable<UserSettledBetHistory>, IEnumerable<UserSettledBetHistoryModel>>(
                    betService.GetSettledBetHistory());
            return View(settledBetHistoryModel);
        }

        public ActionResult Unsettled()
        {
            var unsettledBetItemsModel =
                mapper.Map<IEnumerable<RiskAssessedUnsettledBetItem>, IEnumerable<UnsettledBetItemModel>>(
                    betService.GetUnsettledBets());
            return View(unsettledBetItemsModel);
        }

    }
}