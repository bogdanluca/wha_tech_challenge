using System.Web.Mvc;
using WhaTechChallenge.Repositories;
using WhaTechChallenge.Services;

namespace WhaTechChallenge.Controllers
{
    public class BetHistoryController : Controller
    {
        private readonly IBetHistoryRepository betHistoryRepository;

        public BetHistoryController(IBetHistoryRepository betHistoryRepository)
        {
            this.betHistoryRepository = betHistoryRepository;
        }

        public ActionResult Settled()
        {
            return View(betHistoryRepository.GetSettledBetHistory());
        }

        public ActionResult Unsettled()
        {
            return View(betHistoryRepository.GetUnsettledBetHistory());
        }

    }
}