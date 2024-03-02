using Sitecore.Common;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI;
using System.Linq;
using System.Web.ModelBinding;
using WbbHackathon.Feature.IACarousel.Models;
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

        public SmartCarouselModel GenerateImages(string dataSourceId)
        {
            var model = new SmartCarouselModel();            

            //var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);

            if (!IsModelValid(dataSource, Templates.HeroCarouselAI.Id))
                return model;

            var serviceParameters = new ImageGenerationParameters();
            
            serviceParameters.Prompt = dataSource.Fields[Templates.HeroCarouselAI.Fields.Prompt].Value;
            serviceParameters.Width = int.Parse(dataSource.Fields[Templates.HeroCarouselAI.Fields.Width].Value);
            serviceParameters.Height = int.Parse(dataSource.Fields[Templates.HeroCarouselAI.Fields.Height].Value);
            serviceParameters.NumberOfImages= int.Parse(dataSource.Fields[Templates.HeroCarouselAI.Fields.NumberOfImages].Value);

            var selectedItem = GetSelectedItemFromDroplistField(dataSource, Templates.HeroCarouselAI.Fields.ImageCreativeModel);

            serviceParameters.ModelId = selectedItem.Fields[Templates.ImageCreationModel.Fields.Id].Value;

            var generationResult = _leonardoAIService.GetGenerationId(serviceParameters).Result;

            if (string.IsNullOrEmpty(generationResult.Job.GenerationId))
                return model;

            var imageResults = _leonardoAIService.GetImageResult(generationResult.Job.GenerationId).Result;

            if (imageResults.GenerationsByPk.GeneratedImages.Any())
            {
                imageResults.GenerationsByPk.GeneratedImages.ForEach(image => 
                {
                    var smartImage = new SmartCarouselImage
                    {
                        ID = image.Id.ToString(),
                        Url = image.Url
                    };
                    model.Images.Add(smartImage);   
                });
            }

            model.Prompt = serviceParameters.Prompt;
            model.DataSource = dataSourceId;

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


        private Item GetSelectedItemFromDroplistField(Item item, ID fieldId)
        {
            Field field = item.Fields[fieldId];
            if (field == null || string.IsNullOrEmpty(field.Value))
            {
                return null;
            }

            var fieldSource = field.Source ?? string.Empty;
            var selectedItemPath = fieldSource.TrimEnd('/') + "/" + field.Value;
            return item.Database.GetItem(selectedItemPath);
        }


    }
}