using System.Collections.Generic;

namespace WbbHackathon.Feature.IACarousel.Models
{
    public class SmartCarouselModel
    {
        public List<SmartCarouselImage> Images { get; set; }

        public string Prompt { get; set; }

        public SmartCarouselModel()
        {
            Images = new List<SmartCarouselImage>();
        }
    }
}