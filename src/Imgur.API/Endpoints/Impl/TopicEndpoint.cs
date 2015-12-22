using System.Threading.Tasks;
using System.Net.Http;
using Imgur.API.Enums;
using Imgur.API.Models;
using Imgur.API.Authentication;
using Imgur.API.RequestBuilders;
using Imgur.API.Models.Impl;
using System.Collections.Generic;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    ///     Implementation of topic related actions.
    /// </summary>
    public class TopicEndpoint : EndpointBase, ITopicEndpoint
    {
        /// <summary>
        /// Initializes a new instance of the TopicEndpoint.
        /// </summary>
        /// <param name="client">The API client to use.</param>
        public TopicEndpoint(IApiClient client) : base(client)
        {
        }

        internal TopicEndpoint(IApiClient apiClient, HttpClient httpClient) : base(apiClient, httpClient)
        {
        }

        internal TopicRequestBuilder RequestBuilder { get; } = new TopicRequestBuilder();

        /// <summary>
        ///     Get the list of default topics.
        /// </summary>
        /// <returns>An array of topics.</returns>
        public async Task<ICollection<ITopic>> GetDefaultTopicsAsync()
        {
            var url = "topics/default";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var topics = await SendRequestAsync<Topic[]>(request);
                return topics;
            }
        }

        /// <summary>
        ///     View a single item in a gallery topic.
        /// </summary>
        /// <param name="topicId">The id of the topic.</param>
        /// <param name="itemId">The id of the gallery item.</param>
        /// <returns>A gallery item.</returns>
        public async Task<IGalleryAlbumImageBase> GetTopicGalleryItemAsync(int topicId, string itemId)
        {
            var url = $"topics/{topicId}/{itemId}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var items = await SendRequestAsync<IGalleryAlbumImageBase>(request);
                return items;
            }
        }

        /// <summary>
        ///     View gallery items for a topic.
        /// </summary>
        /// <param name="topicId">The id of the topic.</param>
        /// <param name="sort">How to sort the items in a topic.</param>
        /// <param name="window">How old the items can be.</param>
        /// <param name="page">What page of the topic to fetch.</param>
        /// <returns>An array of gallery items.</returns>
        public async Task<ICollection<IGalleryAlbumImageBase>> GetTopicGalleryItemsAsync(int topicId, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0)
        {
            var sortStr = sort.ToString().ToLower();
            var windowStr = window.ToString().ToLower();
            var url = $"topics/{topicId}/{sortStr}/{windowStr}/{page}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var items = await SendRequestAsync<IGalleryAlbumImageBase[]>(request);
                return items;
            }
        }
    }
}
