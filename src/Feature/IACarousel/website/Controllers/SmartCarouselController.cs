using Sitecore.Mvc.Presentation;
using System.Linq;
using System.Web.Mvc;
using WbbHackathon.Feature.IACarousel.Models;
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
        private const string sourceItemsId = "1BDA9FA7-98B3-4C1E-9C40-E01EFD56780B";

        public SmartCarouselController(IImageGenerationRepository imageGenerationRepository, IUserSmartCarouselRepository userSmartCarouselRepository, IMediaItemRepository mediaItemRepository)
        {
            _imageGenerationRepository = imageGenerationRepository;
            _userSmartCarouselRepository = userSmartCarouselRepository;
            _mediaItemRepository = mediaItemRepository;
        }

        public ActionResult GetSmartCarousel()
        {
            var dataSourceId = RenderingContext.CurrentOrNull?.Rendering.DataSource == null ? Session["dataSourceId"].ToString() : RenderingContext.CurrentOrNull.Rendering.DataSource;
            Session["dataSourceId"] = dataSourceId;
            var model = _imageGenerationRepository.GenerateImages(dataSourceId);
            //SmartCarouselModel model = GenerateMockCarouselData();
            Session["GeneratedCarousel"] = model;
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

            var imageItems = _mediaItemRepository.CreateMediaItem(selectedImagesArray.ToList(), $"/sitecore/media library/Carousel/{prompt}");

            _mediaItemRepository.CreateItem(Templates.UserSmartCarousel.ID.ToString(), sourceItemsId, prompt, imageItems);
            var model = Session["GeneratedCarousel"];
            return View(SmartCarouselView, model);
        }
    }
}