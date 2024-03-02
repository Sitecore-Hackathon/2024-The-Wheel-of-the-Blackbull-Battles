using Sitecore.Common;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System.Dynamic;
using System.Linq;
using WbbHackathon.Feature.IACarousel.Models.Parameters;
using WbbHackathon.Feature.IACarousel.Services;

namespace WbbHackathon.Feature.IACarousel.Repositories
{
    public class ImageGenerationRepository : IImageGenerationRepository
    {
        private readonly ILeonardoAIService _leonardoAIService;

        public ImageGenerationRepository(ILeonardoAIService leonardoAIService)
        {
            _leonardoAIService = leonardoAIService;
        }

        public dynamic GenerateImages()
        {
            dynamic model = new ExpandoObject();

            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);

            if (!IsModelValid(dataSource, Templates.HeroCarouselAI.Id))
                return model;

            var serviceParameters = new ImageGenerationParameters();
            serviceParameters.Prompt = dataSource.Fields[Templates.HeroCarouselAI.Fields.Prompt].Value;
            serviceParameters.Width = int.Parse(dataSource.Fields[Templates.HeroCarouselAI.Fields.Width].Value);
            serviceParameters.Height = int.Parse(dataSource.Fields[Templates.HeroCarouselAI.Fields.Height].Value);
            //serviceParameters.ModelId = dataSource.Fields[Templates.HeroCarouselAI.Fields.ModelId].Value;

            var generationResult = _leonardoAIService.GetGenerationId(serviceParameters).Result;
            var imageResults = _leonardoAIService.GetImageResult(generationResult.Job.GenerationId).Result;

            if (imageResults.GenerationsByPk.GeneratedImages.Any())
            {
                //imageResults.GenerationsByPk.GeneratedImages.ForEach(image => new 
                //{ 
                //    image.Url,
                //    image.Id
                //});
            }

            return model;
        }


        protected bool IsModelValid(Item dataSourceItem, ID templateId)
        {
            if (dataSourceItem == null)
                return false;

            if (!(dataSourceItem.Template.ID == templateId))
                return false;

            return true;
        }


    }
}