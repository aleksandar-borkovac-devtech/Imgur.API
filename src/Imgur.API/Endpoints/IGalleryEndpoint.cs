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
        Task<IGalleryAlbumImageBase[]> GetGalleryAsync(GallerySection section = GallerySection.Hot, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Day, uint page = 0, bool showViral = true);

        /// <summary>
        ///     Returns the image identified by the given id.
        /// </summary>
        /// <param name="id">The id of the image to fetch.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<GalleryImage> GetGalleryImageAsync(string id);

        /// <summary>
        ///     Returns the album identified by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<GalleryAlbum> GetGalleryAlbumAsync(string id);

        /// <summary>
        /// Report an Image in the gallery
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> PostReportAsync(string id, Reporting reason);

        /// <summary>
        /// Get the vote information about an image
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<IVotes> GetVotesAsync(string id);

        /// <summary>
        /// Vote for an image, 'up' or 'down' vote. Send the same value again to undo a vote.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vote"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> PostVoteAsync(string id, Vote vote);

        /// <summary>
        /// Comment on an image in the gallery.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<IComment[]> GetCommentsAsync(string id, CommentSortOrder sort);

        /// <summary>
        /// Create a comment for an image.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> PostCommentAsync(string id, string comment);

        /// <summary>
        /// Reply to a comment that has been created for an image.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commentID"></param>
        /// <param name="reply"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> PostReplyAsync(string id, string commentID, string reply);

        /// <summary>
        /// List all of the IDs for the comments on an image.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> GetCommentIdsAsync(string id);

        /// <summary>
        /// The number of comments on an Image.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> GetCommentCountAsync(string id);

        /// <summary>
        /// Remove an image from the gallery. You must be logged in as the owner of the item to do this action.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> DeleteFromGalleryAsync(string id);

        /// <summary>
        /// View tags for a gallery item.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ITagVote[]> GetGalleryItemTagsAsync(string id);

        /// <summary>
        /// Returns a random set of gallery images.
        /// 
        /// Pages are regenerated every hour.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<IGalleryAlbumImageBase[]> GetRandomItemsAsync(uint page = 0);

        /// <summary>
        /// View images for a gallery tag
        /// </summary>
        /// <param name="tagname"></param>
        /// <param name="sort"></param>
        /// <param name="window"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<ITag> GetTagAsync(string tagname, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0);

        /// <summary>
        /// View a single image in a gallery tag
        /// </summary>
        /// <param name="tagname"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GalleryImage> GetTagImageAsync(string tagname, string id);

        /// <summary>
        /// Vote for a tag, 'up' or 'down' vote. Send the same value again to undo a vote.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tagname"></param>
        /// <param name="vote"></param>
        /// <returns></returns>
        Task<object> PostGalleryTagVoteAsync(string id, string tagname, Vote vote);

        /// <summary>
        /// Share an Album or Image to the Gallery.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="topic"></param>
        /// <param name="acceptTerms"></param>
        /// <param name="Nsfw"></param>
        /// <returns></returns>
        Task<object> PublishToGalleryAsync(string id, string title, string topic = null, bool? acceptTerms = null, bool? Nsfw = null);

        /// <summary>
        /// Search the gallery with a given query string.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sort"></param>
        /// <param name="window"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<IGalleryAlbumImageBase[]> SearchGalleryAsync(string query, GallerySortBy sort = GallerySortBy.Time, GalleryWindow window = GalleryWindow.All, uint page = 0);
    }
}
