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
    ///     Gallery related actions.
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
        ///     Returns the images currently in the gallery.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="sort"></param>
        /// <param name="window"></param>
        /// <param name="page"></param>
        /// <param name="showViral"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
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
        ///     Returns the image identified by the given id.
        /// </summary>
        /// <param name="id">The id of the image to fetch.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
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
        ///     Returns the album identified by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vote"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        public async Task<object> PostVoteAsync(string id, Vote vote)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), postVoteUrl);
        	endpointUrl = string.Format(endpointUrl, id, vote.ToString().ToLower());
        	var result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl);
        	return result;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
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

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content);
            }

        	return result;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commentID"></param>
        /// <param name="reply"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        public async Task<object> PostReplyAsync(string id, string commentID, string reply)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));
        	
        	if(string.IsNullOrEmpty(reply))
        		throw new ArgumentNullException(nameof(reply));
        	
        	if(string.IsNullOrEmpty(commentID))
        		throw new ArgumentNullException(nameof(commentID));
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), postReplyUrl);
        	endpointUrl = string.Format(endpointUrl, id, commentID);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(reply), "comment");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content);
            }
        	return result;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        public async Task<object> DeleteFromGalleryAsync(string id)
        {
        	if(string.IsNullOrEmpty(id))
        		throw new ArgumentNullException(nameof(id));
        	
        	var endpointUrl = string.Concat(GetEndpointBaseUrl(), deleteUrl);
        	endpointUrl = string.Format(endpointUrl, id);
        	var result = await MakeEndpointRequestAsync<object>(HttpMethod.Delete, endpointUrl);
        	return result;
        }

        public async Task<ITagVote[]> GetGalleryItemTagsAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getTagsUrl);
            endpointUrl = string.Format(endpointUrl, id);
            var result = await MakeEndpointRequestAsync<ITagVote[]>(HttpMethod.Get, endpointUrl);
            return result;
        }

        public async Task<IGalleryAlbumImageBase[]> GetRandomItemsAsync(uint page = 0)
        {
            if (page > randomPageMax)
                throw new ArgumentException(nameof(page) + " can not be higher than 50.");

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getRandomUrl);
            endpointUrl = string.Format(endpointUrl, page);
            var result = await MakeEndpointRequestAsync<IGalleryAlbumImageBase[]>(HttpMethod.Get, endpointUrl);
            return result;
        }

        public async Task<ITag> GetTagAsync(string tagname, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0)
        {
            if (string.IsNullOrEmpty(tagname))
                throw new ArgumentNullException(nameof(tagname));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getTagUrl);
            endpointUrl = string.Format(
                endpointUrl,
                sort.ToString().ToLower(),
                window.ToString().ToLower(),
                page);
            var result = await MakeEndpointRequestAsync<ITag>(HttpMethod.Get, endpointUrl);
            return result;
        }
        
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

        public async Task<object> PostGalleryTagVoteAsync(string id, string tagname, Vote vote)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrEmpty(tagname))
                throw new ArgumentNullException(nameof(tagname));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), postTagVoteUrl);
            endpointUrl = string.Format(endpointUrl, id, tagname, vote.ToString().ToLower());

            var result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl);
            return result;
        }

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


                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content);
            }

            return result;
        }

        public async Task<IGalleryAlbumImageBase[]> SearchGalleryAsync(string query, GallerySortBy sort = GallerySortBy.Time, GalleryWindow window = GalleryWindow.All, uint page = 0)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException(nameof(query));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), searchGalleryUrl);
            endpointUrl = string.Format(endpointUrl, sort.ToString().ToLower(), window.ToString().ToLower(), page);
            endpointUrl += "?q=" + WebUtility.UrlEncode(query);

            var result = await MakeEndpointRequestAsync<IGalleryAlbumImageBase[]>(HttpMethod.Get, endpointUrl);
            return result;
        }
    }
}
