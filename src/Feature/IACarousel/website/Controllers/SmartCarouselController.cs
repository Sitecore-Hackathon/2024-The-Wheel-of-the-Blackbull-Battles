using System.Web.Mvc;
using WbbHackathon.Feature.IACarousel.Models;
using WbbHackathon.Feature.IACarousel.Repositories;

namespace WbbHackathon.Feature.IACarousel.Controllers
{
    public class SmartCarouselController : Controller
    {
        //private readonly ISmartCarouselRepository _smartCartCarouselRepository;

        //public SmartCarouselController(ISmartCarouselRepository smartCartCarouselRepository)
        //{
        //    _smartCartCarouselRepository = smartCartCarouselRepository;
        //}

        public ActionResult GetSmartCarousel()
        {
            SmartCarouselModel model = new SmartCarouselModel();
            return View("~/Views/SmartCarousel/SmartCarouselView.cshtml", model);
        }
    }
}