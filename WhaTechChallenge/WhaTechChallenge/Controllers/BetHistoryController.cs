using System.Web.Mvc;
using WhaTechChallenge.Repositories;
using WhaTechChallenge.Services;

namespace WhaTechChallenge.Controllers
{
    public class BetHistoryController : Controller
    {
        private readonly IBetHistoryService betHistoryService;

        public BetHistoryController(IBetHistoryService betHistoryService)
        {
            this.betHistoryService = betHistoryService;
        }

        public ActionResult Settled()
        {
            return View(betHistoryService.GetSettledBetHistory());
        }

        public ActionResult Unsettled()
        {
            return View(betHistoryService.GetUnsettledBetHistory());
        }

    }
}