using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using WbbHackathon.Feature.IACarousel.Models;

using UserSmartCarouselTemplate = WbbHackathon.Feature.IACarousel.Templates.UserSmartCarousel;

namespace WbbHackathon.Feature.IACarousel.Repositories
{
    public class UserSmartCarouselRepository : IUserSmartCarouselRepository
    {
        public UserSmartCarouselModel GetCarouselImages()
        {
            UserSmartCarouselModel model = new UserSmartCarouselModel();

            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);

            if (!IsModelValid(dataSource, UserSmartCarouselTemplate.ID))
                return model;

            MultilistField images = dataSource.Fields[UserSmartCarouselTemplate.Fields.Images];
            Item[] imageItems = images.GetItems();

            foreach (Item imageItem in imageItems)
            {
                MediaItem imageMediaItem = new MediaItem(imageItem);
                model.Images.Add(new Image() { 
                    Alt = imageMediaItem.Alt, 
                    Url = Sitecore.StringUtil.EnsurePrefix('/',Sitecore.Resources.Media.MediaManager.GetMediaUrl(imageMediaItem))
            });
            }

            return model;
        }

        private bool IsModelValid(Item dataSourceItem, ID templateId)
        {
            if (dataSourceItem == null)
                return false;

            if (!(dataSourceItem.Template.ID == templateId))
                return false;

            return true;
        }
    }
}