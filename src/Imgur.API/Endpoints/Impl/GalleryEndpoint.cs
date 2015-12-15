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

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    ///     Implementation of gallery related actions.
    /// </summary>
    public class GalleryEndpoint : EndpointBase, IGalleryEndpoint
    {
        private const string getGalleryUrl = "gallery/{0}/{1}/{2}.json?showViral={3}";
        private const string getGalleryUrl2 = "gallery/{0}/{1}/{2}/{3}.json?showViral={4}";
        private const string getImageUrl = "gallery/image/{0}";
        private const string getAlbumUrl = "gallery/album/{0}";
        private const string postReportUrl = "gallery/{0}/report";
        private const string getVotesUrl = "gallery/{0}/votes";
        private const string postVoteUrl = "gallery/{0}/vote/{1}";
        private const string getCommentsUrl = "gallery/{0}/comments/{1}";
        private const string postCommentUrl = "gallery/{0}/comment";
        private const string postReplyUrl = "gallery/{0}/comment/{1}";
        private const string getCommentIdsUrl = "gallery/{0}/comments/ids";
        private const string getCommentCountUrl = "gallery/{0}/comments/count";
        private const string deleteUrl = "gallery/{0}";
        private const string getTagsUrl = "gallery/{0}/tags";
        private const string getRandomUrl = "gallery/random/random/{0}";
        private const string getTagUrl = "gallery/t/{0}/{1}/{2}/{3}";
        private const string getTagImageUrl = "gallery/t/{0}/{1}";
        private const string postTagVoteUrl = "gallery/{0}/vote/tag/{1}/{2}";
        private const string postPublishUrl = "gallery/{0}";
        private const string searchGalleryUrl = "gallery/search/{0}/{1}/{3}";

        private const uint randomPageMax = 50;

        /// <summary>
        ///     Initializes the endpoint.
        /// </summary>
        /// <param name="apiClient">The client to use.</param>
        public GalleryEndpoint(IApiClient apiClient) : base(apiClient)
        {
        }

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

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getGalleryUrl2);
            endpointUrl = string.Format(
                endpointUrl,
                section.ToString().ToLower(),
                sort.ToString().ToLower(),
                window.ToString().ToLower(),
                page,
                showViral);
            Debug.WriteLine("gallery endpoint url: " + endpointUrl);
            var gallery = await MakeEndpointRequestAsync<IGalleryAlbumImageBase[]>(HttpMethod.Get, endpointUrl);
            return gallery;
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

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getImageUrl);
            endpointUrl = string.Format(endpointUrl, id);
            var image = await MakeEndpointRequestAsync<GalleryImage>(HttpMethod.Get, endpointUrl);
            return image;
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

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getAlbumUrl);
            endpointUrl = string.Format(endpointUrl, id);
            var image = await MakeEndpointRequestAsync<GalleryAlbum>(HttpMethod.Get, endpointUrl);
            return image;
        }
        
        /// <summary>
        ///		Report an item currently in the gallery.
        /// </summary>
        /// <param name="id">The id of the gallery submission to report.</param>
        /// <param name="reason">The reason for reporting the item.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns></returns>
        public async Task<object> PostReportAsync(string id, Reporting reason)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), postReportUrl);
        	endpointUrl = string.Format(endpointUrl, id);
            object ret;

            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(reason.ToString()), "reason");

                ret = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content);
            }

            return ret;
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
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), getVotesUrl);
        	endpointUrl = string.Format(endpointUrl, id);
        	var votes = await MakeEndpointRequestAsync<IVotes>(HttpMethod.Get, endpointUrl);
        	return votes;
        }
        
        /// <summary>
        /// 	Vote for an image, 'up' or 'down' vote. Send the same value again to undo a vote.
        /// </summary>
        /// <param name="id">The id of the gallery submission to vote on.</param>
        /// <param name="vote">The vote to send.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns></returns>
        public async Task<object> PostVoteAsync(string id, Vote vote)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), postVoteUrl);
        	endpointUrl = string.Format(endpointUrl, id, vote.ToString().ToLower());
        	var result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, requiresAuth: true);
        	return result;
        }
        
        /// <summary>
        ///		Get the comments on a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery submission to fetch the comments for.</param>
        /// <param name="sort">How to sort the comments.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns>The comments posted to the gallery submission.</returns>
        public async Task<IComment[]> GetCommentsAsync(string id, CommentSortOrder sort)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), getCommentsUrl);
        	endpointUrl = string.Format(endpointUrl, id, sort.ToString().ToLower());
        	var result = await MakeEndpointRequestAsync<IComment[]>(HttpMethod.Get, endpointUrl);
        	return result;
        }
        
        /// <summary>
        /// 	Create a comment for a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery submission to post a comment on.</param>
        /// <param name="comment">The comment to post.</param>
        /// <exception cref="ArgumentNullException">Thrown when id or comment was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns></returns>
        public async Task<object> PostCommentAsync(string id, string comment)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));
        	
        	if(string.IsNullOrEmpty(comment))
        		throw new ArgumentNullException(nameof(comment));
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), postCommentUrl);
        	endpointUrl = string.Format(endpointUrl, id);

            object result;

            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(comment), "comment");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content, requiresAuth: true);
            }

        	return result;
        }
        
        /// <summary>
        /// 	Reply to a comment that has been created for a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery submission the original comment was posted in.</param>
        /// <param name="commentID">The comment to reply to.</param>
        /// <param name="reply">The reply to post.</param>
        /// <exception cref="ArgumentNullException">Thrown when id, commentID or reply was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns></returns>
        public async Task<object> PostReplyAsync(string id, int commentID, string reply)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));
        	
        	if(string.IsNullOrEmpty(reply))
        		throw new ArgumentNullException(nameof(reply));
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), postReplyUrl);
        	endpointUrl = string.Format(endpointUrl, id, commentID);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(reply), "comment");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content, requiresAuth: true);
            }
        	return result;
        }
        
        /// <summary>
        ///		List all of the IDs for the comments on a gallery submission
        /// </summary>
        /// <param name="id">The id of the gallery submission to fetch the comment ids for.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<object> GetCommentIdsAsync(string id)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), getCommentIdsUrl);
        	endpointUrl = string.Format(endpointUrl, id);
        	var result = await MakeEndpointRequestAsync<object>(HttpMethod.Get, endpointUrl);
        	return result;
        }
        
        /// <summary>
        /// 	The number of comments on a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery submission to get the comment count for.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<object> GetCommentCountAsync(string id)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), getCommentCountUrl);
        	endpointUrl = string.Format(endpointUrl, id);
        	var result = await MakeEndpointRequestAsync<object>(HttpMethod.Get, endpointUrl);
        	return result;
        }

        /// <summary>
        /// 	Remove a submission from the gallery. You must be logged in as the owner of the item to do this action.
        /// </summary>
        /// <param name="id">The id of the submission to remove from the gallery.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<object> DeleteFromGalleryAsync(string id)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), deleteUrl);
        	endpointUrl = string.Format(endpointUrl, id);
        	var result = await MakeEndpointRequestAsync<object>(HttpMethod.Delete, endpointUrl, requiresAuth: true);
        	return result;
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

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getTagsUrl);
            endpointUrl = string.Format(endpointUrl, id);
            var result = await MakeEndpointRequestAsync<ITagVote[]>(HttpMethod.Get, endpointUrl);
            return result;
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

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getRandomUrl);
            endpointUrl = string.Format(endpointUrl, page);
            var result = await MakeEndpointRequestAsync<IGalleryAlbumImageBase[]>(HttpMethod.Get, endpointUrl);
            return result;
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
				throw new ArgumentException(nameof(tagname) + " cannot be Rising.");

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getTagUrl);
            endpointUrl = string.Format(
                endpointUrl,
                sort.ToString().ToLower(),
                window.ToString().ToLower(),
                page);
            var result = await MakeEndpointRequestAsync<ITag>(HttpMethod.Get, endpointUrl);
            return result;
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

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getTagImageUrl);
            endpointUrl = string.Format(endpointUrl, tagname, id);

            var result = await MakeEndpointRequestAsync<GalleryImage>(HttpMethod.Get, endpointUrl);
            return result;
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
        public async Task<object> PostGalleryTagVoteAsync(string id, string tagname, Vote vote)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrEmpty(tagname))
                throw new ArgumentNullException(nameof(tagname));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), postTagVoteUrl);
            endpointUrl = string.Format(endpointUrl, id, tagname, vote.ToString().ToLower());

            var result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, requiresAuth: true);
            return result;
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
        public async Task<object> PublishToGalleryAsync(string id, string title, string topic = null, bool? acceptTerms = null, bool? Nsfw = null)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), postPublishUrl);
            endpointUrl = string.Format(endpointUrl, id);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(title), "title");

                if (!string.IsNullOrEmpty(topic))
                    content.Add(new StringContent(topic), "topic");

                if (acceptTerms != null)
                {
                    var terms = (bool)acceptTerms ? 1 : 0;
                    content.Add(new StringContent(terms.ToString()), "terms");
                }

                if (Nsfw != null)
                {
                    var mature = (bool)Nsfw ? 1 : 0;
                    content.Add(new StringContent(mature.ToString()), "mature");
                }


                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content, requiresAuth: true);
            }

            return result;
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

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), searchGalleryUrl);
            endpointUrl = string.Format(endpointUrl, sort.ToString().ToLower(), window.ToString().ToLower(), page);
            endpointUrl += "?q=" + WebUtility.UrlEncode(query);

            var result = await MakeEndpointRequestAsync<IGalleryAlbumImageBase[]>(HttpMethod.Get, endpointUrl);
            return result;
        }
    }
}
