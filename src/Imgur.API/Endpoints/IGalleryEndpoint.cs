using Imgur.API.Enums;
using Imgur.API.Exceptions;
using Imgur.API.Models;
using System;
using System.Threading.Tasks;
using Imgur.API.Models.Impl;

namespace Imgur.API.Endpoints
{
    /// <summary>
    ///     Gallery related actions.
    /// </summary>
    public interface IGalleryEndpoint : IEndpoint
    {
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
        /// <returns>An array with <see cref="IGalleryAlbumImageBase" /> objects.</returns>
        Task<IGalleryAlbumImageBase[]> GetGalleryAsync(GallerySection section = GallerySection.Hot, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Day, uint page = 0, bool showViral = true);

        /// <summary>
        ///     Fetches the image identified by the given id.
        /// </summary>
        /// <param name="id">The id of the image to fetch.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns>The gallery image identified by the given ID.</returns>
        Task<GalleryImage> GetGalleryImageAsync(string id);

        /// <summary>
        ///     Fetches the album identified by the given id.
        /// </summary>
        /// <param name="id">The id of the album to fetch.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns>The gallery album identified by the given id.</returns>
        Task<GalleryAlbum> GetGalleryAlbumAsync(string id);

        /// <summary>
        ///		Report an item currently in the gallery.
        /// </summary>
        /// <param name="id">The id of the gallery submission to report.</param>
        /// <param name="reason">The reason for reporting the item.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns></returns>
        Task<object> PostReportAsync(string id, Reporting reason);

        /// <summary>
        /// 	Get the vote information about an image
        /// </summary>
        /// <param name="id">The id of the gallery submission to get the votes for.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns>Vote information on the gallery submission.</returns>
        Task<IVotes> GetVotesAsync(string id);

        /// <summary>
        /// 	Vote for an image, 'up' or 'down' vote. Send the same value again to undo a vote.
        /// </summary>
        /// <param name="id">The id of the gallery submission to vote on.</param>
        /// <param name="vote">The vote to send.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns></returns>
        Task<object> PostVoteAsync(string id, Vote vote);

        /// <summary>
        ///		Get the comments on a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery submission to fetch the comments for.</param>
        /// <param name="sort">How to sort the comments.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns>The comments posted to the gallery submission.</returns>
        Task<IComment[]> GetCommentsAsync(string id, CommentSortOrder sort);

        /// <summary>
        /// 	Create a comment for a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery submission to post a comment on.</param>
        /// <param name="comment">The comment to post.</param>
        /// <exception cref="ArgumentNullException">Thrown when id or comment was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns></returns>
        Task<object> PostCommentAsync(string id, string comment);

        /// <summary>
        /// 	Reply to a comment that has been created for a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery submission the original comment was posted in.</param>
        /// <param name="commentID">The comment to reply to.</param>
        /// <param name="reply">The reply to post.</param>
        /// <exception cref="ArgumentNullException">Thrown when id, commentID or reply was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encountered an error.</exception>
        /// <returns></returns>
        Task<object> PostReplyAsync(string id, int commentID, string reply);

        /// <summary>
        ///		List all of the IDs for the comments on a gallery submission
        /// </summary>
        /// <param name="id">The id of the gallery submission to fetch the comment ids for.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        Task<object> GetCommentIdsAsync(string id);

        /// <summary>
        /// 	The number of comments on a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery submission to get the comment count for.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        Task<object> GetCommentCountAsync(string id);

        /// <summary>
        /// 	Remove a submission from the gallery. You must be logged in as the owner of the item to do this action.
        /// </summary>
        /// <param name="id">The id of the submission to remove from the gallery.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        Task<object> DeleteFromGalleryAsync(string id);

        /// <summary>
        /// 	View tags for a gallery submission.
        /// </summary>
        /// <param name="id">The id of the gallery item to fetch tags for.</param>
        /// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns>The tags related to the gallery submission.</returns>
        Task<ITagVote[]> GetGalleryItemTagsAsync(string id);

        /// <summary>
        /// 	Returns a random set of gallery images. Pages are regenerated every hour.
        /// </summary>
        /// <param name="page">The page to fetch.</param>
        /// <exception cref="ArgumentException">Thrown when page was higher than 50.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns>An array of gallery submissions.</returns>
        Task<IGalleryAlbumImageBase[]> GetRandomItemsAsync(uint page = 0);

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
        Task<ITag> GetTagAsync(string tagname, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0);

        /// <summary>
        /// 	View a single image in a gallery tag.
        /// </summary>
        /// <param name="tagname">The name of the tag.</param>
        /// <param name="id">The id of the gallery image to fetch</param>
        /// <exception cref="ArgumentNullException">Thrown when id or tagname was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns>The gallery image identified by the given id.</returns>
        Task<GalleryImage> GetTagImageAsync(string tagname, string id);

        /// <summary>
        /// 	Vote for a tag, 'up' or 'down' vote. Send the same value again to undo a vote.
        /// </summary>
        /// <param name="id">The id of the gallery submission to vote on a tag for.</param>
        /// <param name="tagname">The tag to vote for.</param>
        /// <param name="vote">The vote.</param>
        /// <exception cref="ArgumentNullException">Thrown when id or tagname was null or empty.</exception>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns></returns>
        Task<object> PostGalleryTagVoteAsync(string id, string tagname, Vote vote);

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
        Task<object> PublishToGalleryAsync(string id, string title, string topic = null, bool? acceptTerms = null, bool? Nsfw = null);

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
        Task<IGalleryAlbumImageBase[]> SearchGalleryAsync(string query, GallerySortBy sort = GallerySortBy.Time, GalleryWindow window = GalleryWindow.All, uint page = 0);
    }
}
