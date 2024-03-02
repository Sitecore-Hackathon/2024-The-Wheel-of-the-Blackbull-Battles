using WbbHackathon.Feature.IACarousel.Models;

namespace WbbHackathon.Feature.IACarousel.Repositories
{
    public interface IImageGenerationRepository
    {
        SmartCarouselModel GenerateImages(string dataSourceId);
    }
}