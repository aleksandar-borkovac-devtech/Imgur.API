using Imgur.API.Enums;
using Imgur.API.Exceptions;
using Imgur.API.Models.Impl;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imgur.API.Endpoints.Impl
{
    public partial class GalleryEndpoint
    {
        /// <summary>
        /// View gallery images for a subreddit.
        /// </summary>
        /// <param name="sort">How to sort the results.</param>
        /// <param name="window">The maximum age of the items in the result.</param>
        /// <param name="page">The page of the result.</param>
        /// <param name="subreddit">A valid subreddit name</param>
        /// <exception cref="ArgumentNullException">Thrown when query was null or empty.</exception>
		/// <exception cref="ArgumentException">Thrown when sort was set to GallerySortBy.Rising.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<GalleryRedditImage[]> GetSubredditGalleryAsync(string subreddit, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0)
        {
            if (string.IsNullOrEmpty(subreddit))
                throw new ArgumentNullException(nameof(subreddit));

            var sortStr = sort.ToString().ToLower();
            var windowStr = window.ToString().ToLower();
            var url = $"gallery/r/{subreddit}/{sortStr}/{windowStr}/{page}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var images = await SendRequestAsync<GalleryRedditImage[]>(request);
                return images;
            }
        }

        /// <summary>
        /// View a single image in the subreddit.
        /// </summary>
        /// <param name="subreddit">A valid subreddit name</param>
        /// <param name="id">The id of the image to fetch.</param>
        /// <exception cref="ArgumentNullException">Thrown when query was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<GalleryRedditImage> GetSubredditGalleryImageAsync(string subreddit, string id)
        {
            if (string.IsNullOrEmpty(subreddit))
                throw new ArgumentNullException(nameof(subreddit));

            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var url = $"gallery/r/{subreddit}/{id}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var image = await SendRequestAsync<GalleryRedditImage>(request);
                return image;
            }
        }
    }
}
