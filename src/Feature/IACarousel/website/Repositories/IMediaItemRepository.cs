using System.Collections.Generic;

namespace WbbHackathon.Feature.IACarousel.Repositories
{
    public interface IMediaItemRepository
    {
        List<string> CreateMediaItem(List<string> path, string destination, string database = "master");
    }
}