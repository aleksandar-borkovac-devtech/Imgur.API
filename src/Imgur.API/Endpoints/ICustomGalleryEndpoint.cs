using Imgur.API.Enums;
using Imgur.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Endpoints
{
    /// <summary>
    /// Custom gallery related actions.
    /// </summary>
    public interface ICustomGalleryEndpoint : IEndpoint
    {
        /// <summary>
        /// View images for current user's custom gallery.
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="window"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<ICustomGallery> GetCustomGalleryAsync(GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0);

        /// <summary>
        /// Retrieve user's filtered out gallery.
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="window"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<ICustomGallery> GetFilteredOutGalleryAsync(GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0);

        /// <summary>
        /// View a single image in a user's custom gallery.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IGalleryAlbumImageBase> GetCustomGalleryItemAsync(string id);

        /// <summary>
        /// Add tags to a user's custom gallery.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        Task<object> AddCustomGalleryTagsAsync(string[] tags);

        /// <summary>
        /// Remove tags from a custom gallery.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        Task<object> RemoveCustomGalleryTagsAsync(string[] tags);

        /// <summary>
        /// Filter out a tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        Task<object> AddFilteredOutGalleryTagAsync(string tag);

        /// <summary>
        /// Remove a filtered out tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        Task<object> RemoveFilteredOutGalleryTagAsync(string tag);
    }
}
