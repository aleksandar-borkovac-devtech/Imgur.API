using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.API.Authentication;
using Imgur.API.Enums;
using Imgur.API.Models;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    /// Implementation of topic related actions.
    /// </summary>
    public class TopicEndpoint : EndpointBase, ITopicEndpoint
    {
        /// <summary>
        /// Get the list of default topics.
        /// </summary>
        /// <returns></returns>
        public Task<ITopic> GetDefaultTopicsAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// View a single item in a gallery topic.
        /// </summary>
        /// <param name="topicId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Task<IGalleryAlbumImageBase> GetTopicGalleryItemAsync(string topicId, string itemId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// View gallery items for a topic.
        /// </summary>
        /// <param name="topicId"></param>
        /// <param name="sort"></param>
        /// <param name="window"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public Task<IGalleryAlbumImageBase[]> GetTopicGalleryItemsAsync(string topicId, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0)
        {
            throw new NotImplementedException();
        }
    }
}
