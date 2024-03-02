using Sitecore.Data.Items;
using System.Collections.Generic;

namespace WbbHackathon.Feature.IACarousel.Models
{
    public class UserSmartCarouselModel
    {
        public List<Image> Images { get; set; }

        public UserSmartCarouselModel()
        {
            Images = new List<Image>();
        }
    }
}