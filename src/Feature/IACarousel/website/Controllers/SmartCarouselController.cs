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
        private const string HomeTemplateId = "110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9";

        public SmartCarouselController(IImageGenerationRepository imageGenerationRepository, IUserSmartCarouselRepository userSmartCarouselRepository, IMediaItemRepository mediaItemRepository)
        {
            _imageGenerationRepository = imageGenerationRepository;
            _userSmartCarouselRepository = userSmartCarouselRepository;
            _mediaItemRepository = mediaItemRepository;
        }

        public ActionResult GetSmartCarousel()
        {           
            // var model = _imageGenerationRepository.GenerateImages();   
            SmartCarouselModel model = GenerateMockCarouselData();
            return View(SmartCarouselView, model);
        }

        public ActionResult GetUserSmartCarousel()
        {
            var model = _userSmartCarouselRepository.GetCarouselImages();
            return View(UserSmartCarouselView, model);
        }

        private SmartCarouselModel GenerateMockCarouselData ()
        {
            SmartCarouselModel model = new SmartCarouselModel();
            SmartCarouselImage smartCarouselImage1 = new SmartCarouselImage() { ID = "d41275f3-6d6d-48ec-95e4-7b50b0a80589", Url = "https://cdn.leonardo.ai/users/911ec922-1f78-464b-b890-c38ced86ca94/generations/10dd0c83-edb0-45c4-931b-b17ee6e8f89b/Default_Realistic_photo_animals_jungle_africa_0.jpg" };
            SmartCarouselImage smartCarouselImage2 = new SmartCarouselImage() { ID = "4087033f-5f04-436e-ac25-7a0a34fcc250", Url = "https://cdn.leonardo.ai/users/911ec922-1f78-464b-b890-c38ced86ca94/generations/10dd0c83-edb0-45c4-931b-b17ee6e8f89b/Default_Realistic_photo_animals_jungle_africa_1.jpg" };
            SmartCarouselImage smartCarouselImage3 = new SmartCarouselImage() { ID = "6bbcd0ec-5713-4971-8bfd-ce267df80248", Url = "https://cdn.leonardo.ai/users/911ec922-1f78-464b-b890-c38ced86ca94/generations/10dd0c83-edb0-45c4-931b-b17ee6e8f89b/Default_Realistic_photo_animals_jungle_africa_2.jpg" };
            SmartCarouselImage smartCarouselImage4 = new SmartCarouselImage() { ID = "a32fa490-a557-4edf-8f38-48015edfcd0c", Url = "https://cdn.leonardo.ai/users/911ec922-1f78-464b-b890-c38ced86ca94/generations/10dd0c83-edb0-45c4-931b-b17ee6e8f89b/Default_Realistic_photo_animals_jungle_africa_3.jpg" };
            model.Images.Add(smartCarouselImage1);
            model.Images.Add(smartCarouselImage2);
            model.Images.Add(smartCarouselImage3);
            model.Images.Add(smartCarouselImage4);
            model.Prompt = "Test prompt";
            return model;
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

            _mediaItemRepository.CreateItem(Templates.UserSmartCarousel.ID.ToString(), HomeTemplateId, prompt, imageItems);

            return RedirectToAction("GetUserSmartCarousel");
        }
    }
}