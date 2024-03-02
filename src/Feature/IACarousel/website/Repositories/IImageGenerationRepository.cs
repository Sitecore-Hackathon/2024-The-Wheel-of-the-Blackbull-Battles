using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WbbHackathon.Feature.IACarousel.Models;

namespace WbbHackathon.Feature.IACarousel.Repositories
{
    public interface IImageGenerationRepository
    {
        SmartCarouselModel GenerateImages();
    }
}