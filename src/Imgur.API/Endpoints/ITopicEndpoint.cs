using Imgur.API.Enums;
using Imgur.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Endpoints
{
    /// <summary>
    /// Topic related actions.
    /// </summary>
    public interface ITopicEndpoint : IEndpoint
    {
        /// <summary>
        /// Get the list of default topics.
        /// </summary>
        /// <returns></returns>
        Task<ITopic> GetDefaultTopicsAsync();

        /// <summary>
        /// View gallery items for a topic.
        /// </summary>
        /// <param name="topicId"></param>
        /// <param name="sort"></param>
        /// <param name="window"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<IGalleryAlbumImageBase[]> GetTopicGalleryItemsAsync(string topicId, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0);

        /// <summary>
        /// View a single item in a gallery topic.
        /// </summary>
        /// <param name="topicId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<IGalleryAlbumImageBase> GetTopicGalleryItemAsync(string topicId, string itemId);
    }
}
