using System;
using System.Threading.Tasks;
using Imgur.API.Enums;
using Imgur.API.Models;
using System.Net.Http;
using Imgur.API.Models.Impl;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    /// Implementation of custom gallery related actions.
    /// </summary>
    public class CustomGalleryEndpoint : EndpointBase, ICustomGalleryEndpoint
    {
        private const string getCustomGalleryUrl = "g/custom/{0}/{1}/{2}";
        private const string getFilteredOutGalleryUrl = "g/filtered/{0}/{1}/{2}";
        private const string getCustomGalleryItemUrl = "g/custom/{0}";
        private const string addCustomGalleryTagsUrl = "g/custom/add_tags";
        private const string removeCustomGalleryTagsUrl = "g/custom/remove_tags";
        private const string addFilteredOutGalleryTagUrl = "g/block_tag";
        private const string removeFilteredOutGalleryTagUrl = "g/unblock_tag";

        /// <summary>
        /// Add tags to a user's custom gallery.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<object> AddCustomGalleryTagsAsync(string[] tags)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), addCustomGalleryTagsUrl);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(string.Join(",", tags)), "tags");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, requiresAuth: true);
            }
            return result;
        }

        /// <summary>
        /// Filter out a tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<object> AddFilteredOutGalleryTagAsync(string tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), addFilteredOutGalleryTagUrl);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(tag), "tag");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, requiresAuth: true);
            }
            return result;
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

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getCustomGalleryUrl);
            endpointUrl = string.Format(
                endpointUrl,
                sort.ToString().ToLower(),
                window.ToString().ToLower(),
                page);

            var gallery = await MakeEndpointRequestAsync<CustomGallery>(HttpMethod.Get, endpointUrl, requiresAuth: true);
            return gallery;
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

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getCustomGalleryItemUrl);
            endpointUrl = string.Format(endpointUrl, id);

            var result = await MakeEndpointRequestAsync<IGalleryAlbumImageBase>(HttpMethod.Get, endpointUrl, requiresAuth: true);
            return result;
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
                throw new ArgumentException("Cannot sort custom gallery by rising.");

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getFilteredOutGalleryUrl);
            endpointUrl = string.Format(
                endpointUrl,
                sort.ToString().ToLower(),
                window.ToString().ToLower(),
                page);

            var gallery = await MakeEndpointRequestAsync<CustomGallery>(HttpMethod.Get, endpointUrl, requiresAuth: true);
            return gallery;
        }

        /// <summary>
        /// Remove tags from a custom gallery.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<object> RemoveCustomGalleryTagsAsync(string[] tags)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), removeCustomGalleryTagsUrl);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(string.Join(",", tags)), "tags");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, requiresAuth: true);
            }
            return result;
        }

        /// <summary>
        /// Remove a filtered out tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<object> RemoveFilteredOutGalleryTagAsync(string tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), removeFilteredOutGalleryTagUrl);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(tag), "tag");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, requiresAuth: true);
            }
            return result;
        }
    }
}
