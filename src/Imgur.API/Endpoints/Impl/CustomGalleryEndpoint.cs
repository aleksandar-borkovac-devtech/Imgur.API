using System;
using System.Threading.Tasks;
using Imgur.API.Enums;
using Imgur.API.Models;
using System.Net.Http;
using Imgur.API.Models.Impl;
using Imgur.API.Authentication;
using Imgur.API.RequestBuilders;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    /// Implementation of custom gallery related actions.
    /// </summary>
    public class CustomGalleryEndpoint : EndpointBase, ICustomGalleryEndpoint
    {
        /// <summary>
        /// Initializes a new instance of the CustumGalleryEndpoint.
        /// </summary>
        /// <param name="client">The API client to use.</param>
        public CustomGalleryEndpoint(IApiClient client) : base(client)
        {
        }

        internal CustomGalleryEndpoint(IApiClient apiClient, HttpClient httpClient) : base(apiClient, httpClient)
        {
        }

        internal CustomGalleryRequestBuilder RequestBuilder { get; } = new CustomGalleryRequestBuilder();

        /// <summary>
        /// Add tags to a user's custom gallery.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<bool> AddCustomGalleryTagsAsync(string[] tags)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            var url = "g/custom/add_tags";

            using (var request = RequestBuilder.AddCustomGalleryTagsRequest(url, tags))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }

        /// <summary>
        /// Filter out a tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<bool> AddFilteredOutGalleryTagAsync(string tag)
        {
            if (string.IsNullOrEmpty(tag))
                throw new ArgumentNullException(nameof(tag));

            var url = "g/block_tag";

            using (var request = RequestBuilder.AddBlockedOutGalleryRequest(url, tag))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }

        /// <summary>
        /// View images for current user's custom gallery.
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="window"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<CustomGallery> GetCustomGalleryAsync(GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0)
        {
            if (sort == GallerySortBy.Rising)
                throw new ArgumentException("Cannot sort custom gallery by rising.");

            var sortStr = sort.ToString().ToLower();
            var windowStr = window.ToString().ToLower();
            var url = $"g/custom/{sortStr}/{windowStr}/{page}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var customGallery = await SendRequestAsync<CustomGallery>(request);
                return customGallery;
            }
        }

        /// <summary>
        /// View a single image in a user's custom gallery.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IGalleryAlbumImageBase> GetCustomGalleryItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var url = $"g/custom/{id}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var item = await SendRequestAsync<GalleryAlbumImageBase>(request);
                return item;
            }
        }

        /// <summary>
        /// Retrieve user's filtered out gallery.
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="window"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<CustomGallery> GetFilteredOutGalleryAsync(GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0)
        {
            if (sort == GallerySortBy.Rising)
                throw new ArgumentException("Cannot sort filtered out gallery by rising.");

            var sortStr = sort.ToString().ToLower();
            var windowStr = window.ToString().ToLower();
            var url = $"g/filtered/{sortStr}/{windowStr}/{page}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var customGallery = await SendRequestAsync<CustomGallery>(request);
                return customGallery;
            }
        }

        /// <summary>
        /// Remove tags from a custom gallery.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<bool> RemoveCustomGalleryTagsAsync(string[] tags)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            var url = "g/custom/remove_tags";

            using (var request = RequestBuilder.RemoveCustomGalleryRequest(url, tags))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }

        /// <summary>
        /// Remove a filtered out tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<bool> RemoveFilteredOutGalleryTagAsync(string tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            var url = "g/unblock_tag";

            using (var request = RequestBuilder.RemoveBlockedOutGalleryRequest(url, tag))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }
    }
}
