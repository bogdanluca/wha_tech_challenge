using System.Web.Mvc;
using WhaTechChallenge.Services;

namespace WhaTechChallenge.Controllers
{
    public class HomeController : Controller
    {
        private IMyService myService;

        public HomeController(IMyService myService)
        {
            this.myService = myService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}