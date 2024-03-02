using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbbHackathon.Feature.IACarousel.Models;

namespace WbbHackathon.Feature.IACarousel.Repositories
{
    public interface IUserSmartCarouselRepository
    {
        UserSmartCarouselModel GetCarouselImages();
    }
}
