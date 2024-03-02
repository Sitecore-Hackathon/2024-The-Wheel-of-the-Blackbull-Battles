using System.Linq;
using System.Web.Mvc;
using WbbHackathon.Feature.IACarousel.Repositories;

namespace WbbHackathon.Feature.IACarousel.Controllers
{
    public class SmartCarouselController : Controller
    {
        private readonly IImageGenerationRepository _imageGenerationRepository;
        private readonly IUserSmartCarouselRepository _userSmartCarouselRepository;
        private readonly IMediaItemRepository _mediaItemRepository;

        private const string SmartCarouselView = "~/Views/SmartCarousel/SmartCarouselView.cshtml";
        private const string UserSmartCarouselView = "~/Views/SmartCarousel/UserSmartCarouselView.cshtml";
        private const string HomeTemplateId = "110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9";

        public SmartCarouselController(IImageGenerationRepository imageGenerationRepository, IUserSmartCarouselRepository userSmartCarouselRepository, IMediaItemRepository mediaItemRepository)
        {
            _imageGenerationRepository = imageGenerationRepository;
            _userSmartCarouselRepository = userSmartCarouselRepository;
            _mediaItemRepository = mediaItemRepository;
        }

        public ActionResult GetSmartCarousel()
        {           
            var model = _imageGenerationRepository.GenerateImages();            
            return View(SmartCarouselView, model);
        }

        public ActionResult GetUserSmartCarousel()
        {
            var model = _userSmartCarouselRepository.GetCarouselImages();
            return View(UserSmartCarouselView, model);
        }

        [HttpPost]
        public ActionResult SaveSelectedImages(string selectedImages,string prompt)
        {
            if (string.IsNullOrEmpty(selectedImages))
            {
                return RedirectToAction("GetSmartCarousel");
            }

            var selectedImagesArray = selectedImages.Split(new char[] { '|' },System.StringSplitOptions.RemoveEmptyEntries);

            _mediaItemRepository.CreateMediaItem(selectedImagesArray.ToList(), $"/sitecore/media library/Carousel/{prompt}");

            _mediaItemRepository.CreateItem(Templates.UserSmartCarousel.ID.ToString(), HomeTemplateId, prompt, selectedImagesArray.ToList());

            return RedirectToAction("GetUserSmartCarousel");
        }
    }
}