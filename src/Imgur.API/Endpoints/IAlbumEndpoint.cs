using Imgur.API.Enums;
using Imgur.API.Models.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Endpoints
{
    /// <summary>
    /// Album related actions.
    /// </summary>
    public interface IAlbumEndpoint : IEndpoint
    {
        /// <summary>
        /// Get information about a specific album.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Album> GetAlbumAsync(string id);

        /// <summary>
        /// Return all of the images in the album
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Image[]> GetAlbumImagesAsync(string id);

        /// <summary>
        /// Get information about an image in an album, any additional actions found in <see cref="IImageEndpoint"/> will also work. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="imageId"></param>
        /// <returns></returns>
        Task<Image> GetAlbumImageAsync(string id, string imageId);

        /// <summary>
        /// Create a new album. Optional parameter of ids[] is an array of image ids to add to the album.
        ///
        /// This method is available without authenticating an account. Doing so will create an anonymous album which is not tied to an account.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="privacy"></param>
        /// <param name="layout"></param>
        /// <param name="coverID"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        Task<object> CreateAlbumAsync(
            string title = null, string description = null,
            AlbumPrivacy? privacy = null, AlbumLayout layout = AlbumLayout.Vertical,
            string coverID = null, string[] imageIds = null);

        /// <summary>
        /// Update the information of an album. For anonymous albums, album should be the deletehash that is returned at creation. 
        /// </summary>
        /// <param name="album"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="privacy"></param>
        /// <param name="layout"></param>
        /// <param name="coverID"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        Task<object> UpdateAlbumAsync(string album,
            string title = null, string description = null,
            AlbumPrivacy? privacy = null, AlbumLayout layout = AlbumLayout.Vertical,
            string coverID = null, string[] imageIds = null);

        /// <summary>
        /// Delete an album with a given ID. You are required to be logged in as the user to delete the album. For anonymous albums, album should be the deletehash that is returned at creation. 
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        Task<object> DeleteAlbumAsync(string album);

        /// <summary>
        /// Favorite an album with a given ID. The user is required to be logged in to favorite the album.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<object> FavoriteAlbumAsync(string id);

        /// <summary>
        /// Sets the images for an album, removes all other images and only uses the images in this request. For anonymous albums, album should be the deletehash that is returned at creation. 
        /// </summary>
        /// <param name="album"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        Task<object> SetAlbumImagesAsync(string album, string[] imageIds);

        /// <summary>
        /// Takes parameter, ids[], as an array of ids to add to the album. For anonymous albums, album should be the deletehash that is returned at creation. 
        /// </summary>
        /// <param name="album"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        Task<object> AddAlbumImagesAsync(string album, string[] imageIds);

        /// <summary>
        /// Takes parameter, ids[], as an array of ids to from the album. For anonymous albums, album should be the deletehash that is returned at creation. 
        /// </summary>
        /// <param name="album"></param>
        /// <param name="imageIds"></param>
        /// <returns></returns>
        Task<object> RemoveAlbumImagesAsync(string album, string[] imageIds);
    }
}
