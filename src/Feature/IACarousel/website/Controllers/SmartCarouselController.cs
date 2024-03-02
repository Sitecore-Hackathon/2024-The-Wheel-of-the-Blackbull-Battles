using System.Web.Mvc;
using WbbHackathon.Feature.IACarousel.Models;
using WbbHackathon.Feature.IACarousel.Repositories;

namespace WbbHackathon.Feature.IACarousel.Controllers
{
    public class SmartCarouselController : Controller
    {
        private readonly IImageGenerationRepository _imageGenerationRepository;
        private readonly IUserSmartCarouselRepository _userSmartCarouselRepository;

        public SmartCarouselController(IImageGenerationRepository imageGenerationRepository, IUserSmartCarouselRepository userSmartCarouselRepository)
        {
            _imageGenerationRepository = imageGenerationRepository;
            _userSmartCarouselRepository = userSmartCarouselRepository;
        }

        public ActionResult GetSmartCarousel()
        {
            var model = _imageGenerationRepository.GenerateImages();
            return View("~/Views/SmartCarousel/SmartCarouselView.cshtml", model);
        }

        public ActionResult GetUserSmartCarousel()
        {
            var model = _userSmartCarouselRepository.GetCarouselImages();
            return View("~/Views/SmartCarousel/UserSmartCarouselView.cshtml", model);
        }
    }
}