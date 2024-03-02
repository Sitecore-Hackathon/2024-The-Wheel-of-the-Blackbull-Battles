using System.Threading.Tasks;
using WbbHackathon.Feature.IACarousel.Models;
using WbbHackathon.Feature.IACarousel.Models.Parameters;

namespace WbbHackathon.Feature.IACarousel.Services
{
    public interface ILeonardoAIService
    {
        Task<GenerationModel> GetGenerationId(ImageGenerationParameters parameters);

        Task<GenerationImageResult> GetImageResult(string generationId);
    }
}