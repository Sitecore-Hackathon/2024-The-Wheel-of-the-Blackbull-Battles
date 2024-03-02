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
        private readonly IMediaItemRepository _mediaItemRepository;

        public SmartCarouselController(IImageGenerationRepository imageGenerationRepository, IMediaItemRepository mediaItemRepository)
        {
            _imageGenerationRepository = imageGenerationRepository;
            _mediaItemRepository = mediaItemRepository;
        }

        public ActionResult GetSmartCarousel()
        {           
            var model = _imageGenerationRepository.GenerateImages();            
            return View("~/Views/SmartCarousel/SmartCarouselView.cshtml", model);
        }
    }
}