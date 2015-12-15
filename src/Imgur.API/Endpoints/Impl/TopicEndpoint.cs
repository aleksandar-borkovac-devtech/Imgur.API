using System;
using System.Threading.Tasks;
using Imgur.API.Enums;
using Imgur.API.Models;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    ///     Implementation of topic related actions.
    /// </summary>
    public class TopicEndpoint : EndpointBase, ITopicEndpoint
    {
        /// <summary>
        ///     Get the list of default topics.
        /// </summary>
        /// <returns>An array of topics.</returns>
        public Task<ITopic[]> GetDefaultTopicsAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     View a single item in a gallery topic.
        /// </summary>
        /// <param name="topicId">The id of the topic.</param>
        /// <param name="itemId">The id of the gallery item.</param>
        /// <returns>A gallery item.</returns>
        public Task<IGalleryAlbumImageBase> GetTopicGalleryItemAsync(string topicId, string itemId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     View gallery items for a topic.
        /// </summary>
        /// <param name="topicId">The id of the topic.</param>
        /// <param name="sort">How to sort the items in a topic.</param>
        /// <param name="window">How old the items can be.</param>
        /// <param name="page">What page of the topic to fetch.</param>
        /// <returns>An array of gallery items.</returns>
        public Task<IGalleryAlbumImageBase[]> GetTopicGalleryItemsAsync(string topicId, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0)
        {
            throw new NotImplementedException();
        }
    }
}
