using System.Web.Mvc;
using WbbHackathon.Feature.IACarousel.Models;
using WbbHackathon.Feature.IACarousel.Repositories;

namespace WbbHackathon.Feature.IACarousel.Controllers
{
    public class SmartCarouselController : Controller
    {
        

        public ActionResult GetSmartCarousel()
        {
            SmartCarouselModel model = new SmartCarouselModel();
            return View("~/Views/SmartCarousel/SmartCarouselView.cshtml", model);
        }
    }
}