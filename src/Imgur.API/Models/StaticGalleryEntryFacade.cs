using Imgur.API.Endpoints;
using Imgur.API.Enums;
using Imgur.API.Exceptions;
using Imgur.API.Models.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Models
{
    /// <summary>
    /// Static implementation of gallery entry facade methods.
    /// </summary>
    public class StaticGalleryEntryFacade
    {
        /// <summary>
        ///     Gets the thumbnail url for the encapsulated <see cref="IGalleryAlbumImageBase"/>.
        /// </summary>
        /// <param name="thumbnailSize">The size of the thumbnail.</param>
        /// <param name="item">The item to fetch the thumbnail for.</param>
        /// <returns>Link to the thumbnail.</returns>
        public static string GetThumbnailUrl(IAlbumImageBase item, ThumbnailSize thumbnailSize)
        {
            string id, mime;
            if (item is GalleryImage)
            {
                var image = item as GalleryImage;
                id = image.Id;
                mime = image.Type;
            }
            else
            {
                try
                {
                    var album = item as GalleryAlbum;
                    id = album.Cover;
                    mime = "image/png";
                }
                catch (ImgurException)
                {
                    return null;
                }
            }

            return ImgurHelper.CreateThumbnailUrl(id, thumbnailSize, mime);
        }
        
        /// <summary>
        /// Get the original link from a given thumbnail url.
        /// </summary>
        /// <param name="thumbnailUrl"></param>
        /// <returns></returns>
        public static string GetLinkFromThumbnail(string thumbnailUrl)
        {
            int idx = thumbnailUrl.LastIndexOf('.');
            return thumbnailUrl.Remove(idx - 1, 1);
        }
    }
}
