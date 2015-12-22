using Imgur.API.Enums;
using Imgur.API.Exceptions;
using Imgur.API.Models;
using Imgur.API.Models.Impl;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imgur.API.Endpoints.Impl
{
    public partial class GalleryEndpoint
    {
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
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var sortStr = sort.ToString().ToLower();
            var url = $"gallery/{id}/comments/{sortStr}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var comments = await SendRequestAsync<Comment[]>(request);
                return comments;
            }
        }

        /// <summary>
        /// 	Create a comment for a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery submission to post a comment on.</param>
        /// <param name="comment">The comment to post.</param>
        /// <exception cref="ArgumentNullException">Thrown when id or comment was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns></returns>
        public async Task<bool> PostCommentAsync(string id, string comment)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrEmpty(comment))
                throw new ArgumentNullException(nameof(comment));

            var url = $"gallery/{id}/comment";

            using (var request = RequestBuilder.CommentRequest(url, comment))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
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
        public async Task<bool> PostReplyAsync(string id, int commentID, string reply)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrEmpty(reply))
                throw new ArgumentNullException(nameof(reply));

            var url = $"gallery/{id}/comment/{commentID}";

            using (var request = RequestBuilder.CommentRequest(url, reply))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }

        /// <summary>
        ///		List all of the IDs for the comments on a gallery submission
        /// </summary>
        /// <param name="id">The id of the gallery submission to fetch the comment ids for.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<string> GetCommentIdsAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var url = $"gallery/{id}/comments/ids";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var result = await SendRequestAsync<string>(request);
                return result;
            }
        }

        /// <summary>
        /// 	The number of comments on a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery submission to get the comment count for.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        public async Task<int> GetCommentCountAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var url = $"gallery/{id}/comments/count";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var result = await SendRequestAsync<int>(request);
                return result;
            }
        }
    }
}
