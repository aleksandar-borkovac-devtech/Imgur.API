using Imgur.API.Enums;
using Imgur.API.Models.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Endpoints
{
    public interface IAlbumEndpoint
    {
        Task<Album> GetAlbumAsync(string id);
        Task<Image[]> GetAlbumImagesAsync(string id);
        Task<Image> GetAlbumImageAsync(string id, string imageId);

        Task<object> CreateAlbumAsync(
            string title = null, string description = null,
            AlbumPrivacy? privacy = AlbumPrivacy.Secret, AlbumLayout layout = AlbumLayout.Vertical,
            string coverID = null, string[] imageIds = null);

        Task<object> UpdateAlbumAsync(string album,
            string title = null, string description = null,
            AlbumPrivacy? privacy = null, AlbumLayout layout = AlbumLayout.Vertical,
            string coverID = null, string[] imageIds = null);

        Task<object> DeleteAlbumAsync(string album);

        Task<object> FavoriteAlbumAsync(string id);

        Task<object> SetAlbumImagesAsync(string album, string[] imageIds);
        Task<object> AddAlbumImagesAsync(string album, string[] imageIds);
        Task<object> RemoveAlbumImagesAsync(string album, string[] imageIds);
    }
}
