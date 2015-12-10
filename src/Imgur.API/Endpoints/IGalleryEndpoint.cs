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
    public interface IGalleryEndpoint
    {

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
        Task<IGalleryAlbumImageBase[]> GetGalleryAsync(GallerySection section = GallerySection.Hot, GallerySortBy sort = GallerySortBy.Viral, uint page = 0, bool showViral = true);

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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> PostReportAsync(string id, Reporting reason);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<IVotes> GetVotesAsync(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vote"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> PostVoteAsync(string id, Vote vote);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<IComment[]> GetCommentsAsync(string id, CommentSortOrder sort);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> PostCommentAsync(string id, string comment);

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
        Task<object> PostReplyAsync(string id, string commentID, string reply);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> GetCommentIdsAsync(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> GetCommentCountAsync(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<object> DeleteFromGalleryAsync(string id);

        Task<ITagVote[]> GetGalleryItemTagsAsync(string id);

        Task<IGalleryAlbumImageBase[]> GetRandomItemsAsync(uint page = 0);

        Task<ITag> GetTagAsync(string tagname, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0);

        Task<GalleryImage> GetTagImageAsync(string tagname, string id);

        Task<object> PostGalleryTagVoteAsync(string id, string tagname, Vote vote);

        Task<object> PublishToGalleryAsync(string id, string title, string topic = null, bool? acceptTerms = null, bool? Nsfw = null);

        Task<IGalleryAlbumImageBase[]> SearchGalleryAsync(string query, GallerySortBy sort = GallerySortBy.Time, GalleryWindow window = GalleryWindow.All, uint page = 0);
    }
}
