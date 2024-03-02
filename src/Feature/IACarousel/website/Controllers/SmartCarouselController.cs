using Sitecore.Resources;
using System;
using System.Collections.Generic;
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

        public SmartCarouselController(IImageGenerationRepository imageGenerationRepository, IUserSmartCarouselRepository userSmartCarouselRepository, IMediaItemRepository mediaItemRepository)
        {
            _imageGenerationRepository = imageGenerationRepository;
            _userSmartCarouselRepository = userSmartCarouselRepository;
            _mediaItemRepository = mediaItemRepository;
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