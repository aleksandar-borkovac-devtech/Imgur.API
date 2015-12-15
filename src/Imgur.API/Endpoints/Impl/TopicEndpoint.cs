using System;
using System.Threading.Tasks;
using Imgur.API.Enums;
using Imgur.API.Models;
using System.Net.Http;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    ///     Implementation of topic related actions.
    /// </summary>
    public class TopicEndpoint : EndpointBase, ITopicEndpoint
    {
        private const string getDefaultTopics = "topics/defaults";
        private const string getGalleryTopic = "topics/{0}/{1}/{2}/{3}";
        private const string getGalleryTopicItem = "topics/{0}/{1}";

        /// <summary>
        ///     Get the list of default topics.
        /// </summary>
        /// <returns>An array of topics.</returns>
        public async Task<ITopic[]> GetDefaultTopicsAsync()
        {
            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getDefaultTopics);

            var topics = await MakeEndpointRequestAsync<ITopic[]>(HttpMethod.Get, endpointUrl);
            return topics;
        }

        /// <summary>
        ///     View a single item in a gallery topic.
        /// </summary>
        /// <param name="topicId">The id of the topic.</param>
        /// <param name="itemId">The id of the gallery item.</param>
        /// <returns>A gallery item.</returns>
        public async Task<IGalleryAlbumImageBase> GetTopicGalleryItemAsync(int topicId, string itemId)
        {
            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getGalleryTopicItem);
            endpointUrl = string.Format(endpointUrl, topicId, itemId);

            var items = await MakeEndpointRequestAsync<IGalleryAlbumImageBase>(HttpMethod.Get, endpointUrl);
            return items;
        }

        /// <summary>
        ///     View gallery items for a topic.
        /// </summary>
        /// <param name="topicId">The id of the topic.</param>
        /// <param name="sort">How to sort the items in a topic.</param>
        /// <param name="window">How old the items can be.</param>
        /// <param name="page">What page of the topic to fetch.</param>
        /// <returns>An array of gallery items.</returns>
        public async Task<IGalleryAlbumImageBase[]> GetTopicGalleryItemsAsync(int topicId, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0)
        {
            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getGalleryTopicItem);
            endpointUrl = string.Format(endpointUrl, topicId, sort, window, page);

            var items = await MakeEndpointRequestAsync<IGalleryAlbumImageBase[]>(HttpMethod.Get, endpointUrl);
            return items;
        }
    }
}
