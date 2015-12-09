using Imgur.API.Exceptions;
using Imgur.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.Windows.Models;

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
        Task<IGalleryAlbumImageBase[]> GetGalleryAsync(GallerySection section = GallerySection.Hot, GallerySortBy sort = GallerySortBy.Viral, uint page = 0, bool showViral=true);

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

        Task<ITag> GetTagAsync(string tagname, GallerySortBy sort = GallerySortBy.Viral, uint page = 0);
        Task<ITag> GetTagAsync(string tagname, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0);

        Task<IGalleryAlbumImageBase> GetTagImageAsync(string tagname, string id);

        Task<ITagVote[]> GetGalleryItemTagsAsync(string id);

        Task<IBasic<object>> PostGalleryTagVoteAsync(string id, string tagname, Vote vote);

        Task<IGalleryAlbumImageBase[]> GetRandomItemsAsync(uint page = 0);

        Task<IBasic<object>> PublishToGalleryAsync(string title, string topic = null, bool acceptTerms = false, bool NSFW = false);

        Task<IBasic<object>> DeleteFromGalleryAsync(string id);

        Task<GalleryAlbum> GetGalleryAlbumAsync(string id);

        /// <summary>
        ///     Returns the image identified by the given id.
        /// </summary>
        /// <param name="id">The id of the image to fetch.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        Task<GalleryImage> GetGalleryImageAsync(string id);
    }
}
