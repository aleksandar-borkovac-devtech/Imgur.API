using Imgur.API.Enums;
using Imgur.API.Exceptions;
using Imgur.API.Models;
using Imgur.API.Models.Impl;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imgur.API.Endpoints.Impl
{
    public partial class GalleryEndpoint
    {
        /// <summary>
        /// View images for memes subgallery.
        /// </summary>
        /// <param name="sort">How to sort the results.</param>
        /// <param name="window">The maximum age of the items in the result.</param>
        /// <param name="page">The page of the result.</param>
        /// <exception cref="ArgumentNullException">Thrown when query was null or empty.</exception>
		/// <exception cref="ArgumentException">Thrown when sort was set to GallerySortBy.Rising.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<ICollection<IGalleryMeme>> GetMemesSubGalleryAsync(GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0)
        {
            var sortStr = sort.ToString().ToLower();
            var windowStr = window.ToString().ToLower();
            var url = $"g/memes/{sort}/{window}/{page}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var images = await SendRequestAsync<IGalleryMeme[]>(request);
                return images;
            }
        }

        /// <summary>
        /// View a single image in the memes gallery.
        /// </summary>
        /// <param name="id">The id of the image to fetch.</param>
        /// <exception cref="ArgumentNullException">Thrown when query was null or empty.</exception>
		/// <exception cref="ArgumentException">Thrown when sort was set to GallerySortBy.Rising.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<IGalleryMemeImage> GetMemesSubGalleryImageAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var url = $"g/memes/{id}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var image = await SendRequestAsync<GalleryMemeImage>(request);
                return image;
            }
        }
    }
}
