using System.Web.Mvc;
using WhaTechChallenge.Services;

namespace WhaTechChallenge.Controllers
{
    public class BetsController : Controller
    {
        private readonly IBetService betService;

        public BetsController(IBetService betService)
        {
            this.betService = betService;
        }

        public ActionResult Settled()
        {
            return View(betService.GetSettledBetHistory());
        }

        public ActionResult Unsettled()
        {
            return View(betService.GetUnsettledBets());
        }

    }
}