using Microsoft.AspNetCore.Mvc;

namespace BlackBox_TrackRoute_Application.Controllers
{
    public class PlanRouteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
