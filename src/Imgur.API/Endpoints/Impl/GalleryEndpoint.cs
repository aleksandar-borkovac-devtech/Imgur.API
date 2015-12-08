using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.API.Models;
using Imgur.API.Authentication;
using System.Net.Http;
using Imgur.API.Exceptions;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    ///     Gallery related actions.
    /// </summary>
    public class GalleryEndpoint : EndpointBase, IGalleryEndpoint
    {
        private const string getGalleryUrl = "gallery/{0}/{1}/{2}.json?showViral={3}";
        private const string getImageUrl = "gallery/image/{0}";

        /// <summary>
        ///     Initializes the endpoint.
        /// </summary>
        /// <param name="apiClient">The client to use.</param>
        public GalleryEndpoint(IApiClient apiClient) : base(apiClient)
        {
        }

        /// <summary>
        ///     Returns the images currently in the gallery.
        /// </summary>
        /// <param name="section">What section of the gallery to fetch.</param>
        /// <param name="sort">How to sort the gallery.</param>
        /// <param name="page">What page of the gallery to fetch.</param>
        /// <param name="showViral">Whether to show viral images or not.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        public async Task<IGalleryItem[]> GetGalleryAsync(GallerySection section = GallerySection.Hot, GallerySortBy sort = GallerySortBy.Viral, uint page = 0, bool showViral = true)
        {
            if(sort == GallerySortBy.Rising && section != GallerySection.User)
                throw new ArgumentException(nameof(sort) + " can only be rising if " + nameof(section) + " is user.");

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getGalleryUrl);
            endpointUrl = string.Format(
                endpointUrl,
                section.ToString().ToLower(),
                sort.ToString().ToLower(),
                page,
                showViral);
            var gallery = await MakeEndpointRequestAsync<IGalleryItem[]>(HttpMethod.Get, endpointUrl);
            return gallery;
        }

        /// <summary>
        ///     Returns the image identified by the given id.
        /// </summary>
        /// <param name="id">The id of the image to fetch.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        public async Task<IGalleryImage> GetGalleryImageAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(id);

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getImageUrl);
            endpointUrl = string.Format(endpointUrl, id);
            var image = await MakeEndpointRequestAsync<IGalleryImage>(HttpMethod.Get, endpointUrl);
            return image;
        }
    }
}
