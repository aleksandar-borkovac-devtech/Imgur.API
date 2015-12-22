using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.API.Enums;
using Imgur.API.Models;
using Imgur.API.Authentication;
using System.Net.Http;
using Imgur.API.Exceptions;
using Imgur.API.Models.Impl;
using System.Net;
using System.Diagnostics;
using Imgur.API.RequestBuilders;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    ///     Implementation of gallery related actions.
    /// </summary>
    public partial class GalleryEndpoint : EndpointBase, IGalleryEndpoint
    {
        private const uint randomPageMax = 50;

        /// <summary>
        ///     Initializes the endpoint.
        /// </summary>
        /// <param name="apiClient">The client to use.</param>
        public GalleryEndpoint(IApiClient apiClient) : base(apiClient)
        {
        }

        internal GalleryEndpoint(IApiClient client, HttpClient httpClient) : base(client, httpClient)
        {
        }

        internal GalleryRequestBuilder RequestBuilder { get; } = new GalleryRequestBuilder();

        /// <summary>
        ///     Fetches gallery submissions.
        /// </summary>
        /// <param name="section">The section of the gallery to fetch.</param>
        /// <param name="sort">How to sort the gallery.</param>
        /// <param name="window">The maximum age of the submissions to fetch.</param>
        /// <param name="page">What page of the gallery to fetch.</param>
        /// <param name="showViral">If true, viral pots will be included. If false, viral posts will be excluded.</param>
        /// <exception cref="ArgumentException">Thrown when arguments are invalid or conflicting.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns>An array with gallery submissions.</returns>
        public async Task<IGalleryAlbumImageBase[]> GetGalleryAsync(GallerySection section = GallerySection.Hot, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Day, uint page = 0, bool showViral = true)
        {
            if (sort == GallerySortBy.Rising && section != GallerySection.User)
                throw new ArgumentException(nameof(sort) + " can only be rising if " + nameof(section) + " is user.");

            var sectionStr = section.ToString().ToLower();
            var sortStr = sort.ToString().ToLower();
            var windowStr = window.ToString().ToLower();

            var url = $"gallery/{sectionStr}/{sortStr}/{windowStr}/{page}.json?showViral={showViral}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var gallery = await SendRequestAsync<IGalleryAlbumImageBase[]>(request);
                return gallery;
            }
        }

        /// <summary>
        ///     Fetches the image identified by the given id.
        /// </summary>
        /// <param name="id">The id of the image to fetch.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns>The gallery image identified by the given ID.</returns>
        public async Task<GalleryImage> GetGalleryImageAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            	throw new ArgumentNullException(nameof(id));

            var url = $"gallery/image/{id}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var image = await SendRequestAsync<GalleryImage>(request);
                return image;
            }
        }

        /// <summary>
        ///     Fetches the album identified by the given id.
        /// </summary>
        /// <param name="id">The id of the album to fetch.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns>The gallery album identified by the given id.</returns>
        public async Task<GalleryAlbum> GetGalleryAlbumAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var url = $"gallery/album/{id}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var album = await SendRequestAsync<GalleryAlbum>(request);
                return album;
            };
        }
        
        /// <summary>
        ///		Report an item currently in the gallery.
        /// </summary>
        /// <param name="id">The id of the gallery submission to report.</param>
        /// <param name="reason">The reason for reporting the item.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns></returns>
        public async Task<bool> PostReportAsync(string id, Reporting reason)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));

            var url = $"gallery/{id}/report";

            using (var request = RequestBuilder.PostReportRequest(url, reason))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }
        
        /// <summary>
        /// 	Get the vote information about an image
        /// </summary>
        /// <param name="id">The id of the gallery submission to get the votes for.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns>Vote information on the gallery submission.</returns>
        public async Task<IVotes> GetVotesAsync(string id)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));

            var url = $"gallery/{id}/votes";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var votes = await SendRequestAsync<Votes>(request);
                return votes;
            }
        }
        
        /// <summary>
        /// 	Vote for an image, 'up' or 'down' vote. Send the same value again to undo a vote.
        /// </summary>
        /// <param name="id">The id of the gallery submission to vote on.</param>
        /// <param name="vote">The vote to send.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns></returns>
        public async Task<bool> PostVoteAsync(string id, Vote vote)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));

            var voteStr = vote.ToString().ToLower();
            var url = $"gallery/{id}/vote/{voteStr}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Post, url))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }

        /// <summary>
        /// 	Remove a submission from the gallery. You must be logged in as the owner of the item to do this action.
        /// </summary>
        /// <param name="id">The id of the submission to remove from the gallery.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<bool> DeleteFromGalleryAsync(string id)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));

            var url = $"gallery/{id}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Delete, url))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }

        /// <summary>
        /// 	View tags for a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery item to fetch tags for.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns>The tags related to the gallery submission.</returns>
        public async Task<ITagVote[]> GetGalleryItemTagsAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var url = $"gallery/{id}/tags";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var result = await SendRequestAsync<TagVote[]>(request);
                return result;
            }
        }

        /// <summary>
        /// 	Returns a random set of gallery images. Pages are regenerated every hour.
        /// </summary>
        /// <param name="page">The page to fetch.</param>
        /// <exception cref="ArgumentException">Thrown when page was higher than 50.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns>An array of gallery submissions.</returns>
        public async Task<IGalleryAlbumImageBase[]> GetRandomItemsAsync(uint page = 0)
        {
            if (page > randomPageMax)
                throw new ArgumentException(nameof(page) + " can not be higher than 50.");

            var url = $"gallery/random/random/{page}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var items = await SendRequestAsync<IGalleryAlbumImageBase[]>(request);
                return items;
            }
        }

        /// <summary>
        /// 	View images for a gallery tag
        /// </summary>
        /// <param name="tagname">The name of the tag to fetch items for.</param>
        /// <param name="sort">How to sort the items.</param>
        /// <param name="window">The maximum age of the items.</param>
        /// <param name="page">The page to fetch.</param>
        /// <exception cref="ArgumentNullException">Thrown when tagname was null or empty.</exception>
		/// <exception cref="ArgumentException">Thrown when sort was set to GallerySortBy.Rising.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns>Information about the tag and an array of gallery submissions.</returns>
        public async Task<ITag> GetTagAsync(string tagname, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0)
        {
            if (string.IsNullOrEmpty(tagname))
                throw new ArgumentNullException(nameof(tagname));
				
			if(sort == GallerySortBy.Rising)
				throw new ArgumentException(nameof(sort) + " cannot be Rising.");

            var sortStr = sort.ToString().ToLower();
            var windowStr = window.ToString().ToLower();

            var url = $"gallery/t/{tagname}/{sort}/{window}/{page}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var tag = await SendRequestAsync<Tag>(request);
                return tag;
            }
        }

        /// <summary>
        /// 	View a single image in a gallery tag.
        /// </summary>
        /// <param name="tagname">The name of the tag.</param>
        /// <param name="id">The id of the gallery image to fetch</param>
        /// <exception cref="ArgumentNullException">Thrown when id or tagname was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns>The gallery image identified by the given id.</returns>
        public async Task<GalleryImage> GetTagImageAsync(string tagname, string id)
        {
            if (string.IsNullOrEmpty(tagname))
                throw new ArgumentNullException(nameof(tagname));

            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var url = $"gallery/t/{tagname}/{id}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var image = await SendRequestAsync<GalleryImage>(request);
                return image;
            }
        }

        /// <summary>
        /// 	Vote for a tag, 'up' or 'down' vote. Send the same value again to undo a vote.
        /// </summary>
        /// <param name="id">The id of the gallery submission to vote on a tag for.</param>
        /// <param name="tagname">The tag to vote for.</param>
        /// <param name="vote">The vote.</param>
        /// <exception cref="ArgumentNullException">Thrown when id or tagname was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<bool> PostGalleryTagVoteAsync(string id, string tagname, Vote vote)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrEmpty(tagname))
                throw new ArgumentNullException(nameof(tagname));

            var url = $"gallery/{id}/vote/tag/{tagname}/{vote}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Post, url))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }

        /// <summary>
        /// 	Share an Album or Image to the Gallery.
        /// </summary>
        /// <param name="id">The id of the album or image to share.</param>
        /// <param name="title">The title for the submission.</param>
        /// <param name="topic">The topic for the submission.</param>
        /// <param name="acceptTerms">Whether or not the user has accepted the Imgur terms of service.</param>
        /// <param name="Nsfw">Whether or not the submission is nsfw.</param>
        /// <exception cref="ArgumentNullException">Thrown when id or title was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<bool> PublishToGalleryAsync(string id, string title, string topic = null, bool? acceptTerms = null, bool? Nsfw = null)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            var url = $"gallery/{id}";

            using (var request = RequestBuilder.PublishRequest(url, title, topic, acceptTerms, Nsfw))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }

        /// <summary>
        /// 	Search the gallery with a given query string.
        /// </summary>
        /// <param name="query">The query to use for searching.</param>
        /// <param name="sort">How to sort the results.</param>
        /// <param name="window">The maximum age of the items in the result.</param>
        /// <param name="page">The page of the result.</param>
        /// <exception cref="ArgumentNullException">Thrown when query was null or empty.</exception>
		/// <exception cref="ArgumentException">Thrown when sort was set to GallerySortBy.Rising.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns>An array of gallery submissions matching the query.</returns>
        public async Task<IGalleryAlbumImageBase[]> SearchGalleryAsync(string query, GallerySortBy sort = GallerySortBy.Time, GalleryWindow window = GalleryWindow.All, uint page = 0)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException(nameof(query));
				
			if(sort == GallerySortBy.Rising)
				throw new ArgumentException(nameof(query) + " cannot be Rising.");

            var sortStr = sort.ToString().ToLower();
            var windowStr = window.ToString().ToLower();
            var queryStr = WebUtility.UrlEncode(query);
            var url = $"gallery/search/{sortStr}/{windowStr}/{page}?q={queryStr}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var items = await SendRequestAsync<IGalleryAlbumImageBase[]>(request);
                return items;
            }
        }
    }
}
