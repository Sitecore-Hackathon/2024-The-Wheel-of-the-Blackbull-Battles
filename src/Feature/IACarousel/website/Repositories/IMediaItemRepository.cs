using System.Collections.Generic;

namespace WbbHackathon.Feature.IACarousel.Repositories
{
    public interface IMediaItemRepository
    {
        List<string> CreateMediaItem(string[] path, string id, string destination, string database);
    }
}