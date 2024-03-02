using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace WbbHackathon.Feature.IACarousel.Repositories
{
    public class MediaItemRepository : IMediaItemRepository
    {
        public List<string> CreateMediaItem(List<string> path, string destination, string database = "master")
        {
            List<string> result = new List<string>();            

            foreach (var item in path)
            {             
                
                string fileName = $"{item.Split('/').Last()}";

                int i = 0;
                Item mediaItem = null;
                var request = WebRequest.Create(item);

                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                stream.CopyTo(memoryStream);

                                var mediaCreator = new MediaCreator();
                                var options = new MediaCreatorOptions
                                {
                                    Versioned = false,
                                    IncludeExtensionInItemName = false,
                                    Database = Factory.GetDatabase(database),
                                    Destination = $"{destination}/{ fileName.Split('.').First()}"
                                };

                                using (new SecurityDisabler())
                                {
                                    mediaItem = mediaCreator.CreateFromStream(memoryStream, fileName, options);
                                }

                                result.Add(mediaItem.ID.ToString());
                            }
                        }
                    }
                }
            }

            return result;
        }     
    }
}