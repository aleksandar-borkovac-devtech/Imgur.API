using Imgur.API.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.API.Enums;
using Imgur.API.Models.Impl;
using System.Net.Http;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    /// Implements album related actions.
    /// </summary>
    public class AlbumEndpoint : EndpointBase, IAlbumEndpoint
    {
        private const string getAlbumUrl = "album/{0}";
        private const string getAlbumImagesUrl = "album/{0}/images";
        private const string getAlbumImageUrl = "album/{0}/image/{1}";
        private const string createAlbumUrl = "album";
        private const string updateAlbumUrl = "album/{0}";
        private const string deleteAlbumUrl = "album/{0}";
        private const string favoriteAlbumUrl = "album/{0}/favorite";
        private const string setAlbumImagesUrl = "album/{0}";
        private const string addAlbumImagesUrl = "album/{0}/add";
        private const string removeAlbumImagesUrl = "album/{0}/remove_images";

        /// <summary>
        /// Initializes the endpoint.
        /// </summary>
        /// <param name="client"></param>
        public AlbumEndpoint(IApiClient client) : base(client)
        {
        }

        /// <summary>
        /// Get information about a specific album.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Album> GetAlbumAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getAlbumUrl);
            endpointUrl = string.Format(endpointUrl, id);
            var album = await MakeEndpointRequestAsync<Album>(HttpMethod.Get, endpointUrl);
            return album;
        }

        /// <summary>
        /// Get information about an image in an album, any additional actions found in <see cref="IImageEndpoint"/> will also work. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public async Task<Image> GetAlbumImageAsync(string id, string imageId)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentNullException(nameof(imageId));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getAlbumImageUrl);
            endpointUrl = string.Format(endpointUrl, id, imageId);
            var image = await MakeEndpointRequestAsync<Image>(HttpMethod.Get, endpointUrl);
            return image;
        }

        /// <summary>
        /// Return all of the images in the album
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Image[]> GetAlbumImagesAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getAlbumImagesUrl);
            endpointUrl = string.Format(endpointUrl, id);
            var images = await MakeEndpointRequestAsync<Image[]>(HttpMethod.Get, endpointUrl);
            return images;
        }

        /// <summary>
        /// Create a new album. Optional parameter of ids[] is an array of image ids to add to the album.
        ///
        /// This method is available without authenticating an account. Doing so will create an anonymous album which is not tied to an account.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="privacy"></param>
        /// <param name="layout"></param>
        /// <param name="coverID"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        public async Task<object> CreateAlbumAsync(
            string title = null, string description = null,
            AlbumPrivacy? privacy = null, AlbumLayout layout = AlbumLayout.Vertical,
            string coverID = null, string[] imageIds = null)
        {
            var endpointUrl = string.Concat(GetEndpointBaseUrl(), createAlbumUrl);

            object result;

            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                if (!string.IsNullOrEmpty(title))
                    content.Add(new StringContent(title), "title");

                if (!string.IsNullOrEmpty(description))
                    content.Add(new StringContent(description), "description");

                if (!string.IsNullOrEmpty(coverID))
                    content.Add(new StringContent(coverID), "cover");

                if (privacy != null)
                    content.Add(new StringContent(privacy.ToString().ToLower()), "privacy");

                if (imageIds != null)
                    content.Add(new StringContent(string.Join(",", imageIds)), "ids");

                content.Add(new StringContent(layout.ToString().ToLower()), "layout");


                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content);
            }

            return result;
        }

        /// <summary>
        /// Takes parameter, ids[], as an array of ids to add to the album. For anonymous albums, album should be the deletehash that is returned at creation. 
        /// </summary>
        /// <param name="album"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        public async Task<object> AddAlbumImagesAsync(string album, string[] imageIds)
        {
            if (string.IsNullOrEmpty(album))
                throw new ArgumentNullException(nameof(album));

            if (imageIds == null)
                throw new ArgumentNullException(nameof(imageIds));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), addAlbumImagesUrl);
            endpointUrl = string.Format(endpointUrl, album);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(string.Join(",", imageIds)), "ids");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content);
            }

            return result;
        }

        /// <summary>
        /// Delete an album with a given ID. You are required to be logged in as the user to delete the album. For anonymous albums, album should be the deletehash that is returned at creation. 
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        public async Task<object> DeleteAlbumAsync(string album)
        {
            if (string.IsNullOrEmpty(album))
                throw new ArgumentNullException(nameof(album));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), deleteAlbumUrl);
            endpointUrl = string.Format(endpointUrl, album);

            var result = await MakeEndpointRequestAsync<object>(HttpMethod.Delete, endpointUrl);
            return result;
        }

        /// <summary>
        /// Favorite an album with a given ID. The user is required to be logged in to favorite the album.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<object> FavoriteAlbumAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), favoriteAlbumUrl);
            endpointUrl = string.Format(endpointUrl, id);

            var result = await MakeEndpointRequestAsync<object>(HttpMethod.Delete, endpointUrl, requiresAuth: true);
            return result;
        }

        /// <summary>
        /// Takes parameter, ids[], as an array of ids to from the album. For anonymous albums, album should be the deletehash that is returned at creation. 
        /// </summary>
        /// <param name="album"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        public async Task<object> RemoveAlbumImagesAsync(string album, string[] imageIds)
        {
            if (string.IsNullOrEmpty(album))
                throw new ArgumentNullException(nameof(album));

            if (imageIds == null)
                throw new ArgumentNullException(nameof(imageIds));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), removeAlbumImagesUrl);
            endpointUrl = string.Format(endpointUrl, album);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(string.Join(",", imageIds)), "ids");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content);
            }

            return result;
        }

        /// <summary>
        /// Sets the images for an album, removes all other images and only uses the images in this request. For anonymous albums, album should be the deletehash that is returned at creation. 
        /// </summary>
        /// <param name="album"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        public async Task<object> SetAlbumImagesAsync(string album, string[] imageIds)
        {
            if (string.IsNullOrEmpty(album))
                throw new ArgumentNullException(nameof(album));

            if (imageIds == null)
                throw new ArgumentNullException(nameof(imageIds));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), setAlbumImagesUrl);
            endpointUrl = string.Format(endpointUrl, album);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(string.Join(",", imageIds)), "ids");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content);
            }

            return result;
        }

        /// <summary>
        /// Update the information of an album. For anonymous albums, album should be the deletehash that is returned at creation. 
        /// </summary>
        /// <param name="album"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="privacy"></param>
        /// <param name="layout"></param>
        /// <param name="coverID"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        public async Task<object> UpdateAlbumAsync(string album,
            string title = null, string description = null,
            AlbumPrivacy? privacy = null, AlbumLayout layout = AlbumLayout.Vertical,
            string coverID = null, string[] imageIds = null)
        {
            if (string.IsNullOrEmpty(album))
                throw new ArgumentNullException(nameof(album));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), updateAlbumUrl);
            endpointUrl = string.Format(endpointUrl, album);

            object result;

            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                if (!string.IsNullOrEmpty(title))
                    content.Add(new StringContent(title), "title");

                if (!string.IsNullOrEmpty(description))
                    content.Add(new StringContent(description), "description");

                if (!string.IsNullOrEmpty(coverID))
                    content.Add(new StringContent(coverID), "cover");

                if (privacy != null)
                    content.Add(new StringContent(privacy.ToString().ToLower()), "privacy");

                if (imageIds != null)
                    content.Add(new StringContent(string.Join(",", imageIds)), "ids");

                content.Add(new StringContent(layout.ToString().ToLower()), "layout");


                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content);
            }

            return result;
        }
    }
}
