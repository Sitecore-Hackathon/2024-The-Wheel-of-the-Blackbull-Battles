using System.Web.Mvc;
using WbbHackathon.Feature.IACarousel.Models;
using WbbHackathon.Feature.IACarousel.Repositories;

namespace WbbHackathon.Feature.IACarousel.Controllers
{
    public class SmartCarouselController : Controller
    {
        private readonly IImageGenerationRepository _imageGenerationRepository;

        public SmartCarouselController(IImageGenerationRepository imageGenerationRepository)
        {
            _imageGenerationRepository = imageGenerationRepository;
        }

        public ActionResult GetSmartCarousel()
        {
            var model = _imageGenerationRepository.GenerateImages();
            return View("~/Views/SmartCarousel/SmartCarouselView.cshtml", model);
        }
    }
}