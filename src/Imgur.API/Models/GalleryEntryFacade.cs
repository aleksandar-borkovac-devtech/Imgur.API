using Imgur.API.Endpoints;
using Imgur.API.Enums;
using Imgur.API.Exceptions;
using Imgur.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Models
{
    /// <summary>
    /// A facade that encapsulates either an <see cref="GalleryImage"/> or an <see cref="GalleryAlbum"/>, meant generalize dealing with them.
    /// </summary>
    public class GalleryEntryFacade
    {
        private GalleryImage image;
        private GalleryAlbum album;

        private IGalleryAlbumImageBase item;

        /// <summary>
        /// The gallery item being encapsulated.
        /// </summary>
        public IGalleryAlbumImageBase Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;

                if (item is GalleryImage)
                {
                    image = value as GalleryImage;
                    album = null;
                }
                else
                {
                    image = null;
                    album = value as GalleryAlbum;
                }
            }
        }

        /// <summary>
        /// Initializes the facade with the given <see cref="GalleryItem"/>.
        /// </summary>
        /// <param name="item"></param>
        public GalleryEntryFacade(IGalleryAlbumImageBase item)
        {
            Item = item;
        }

        /// <summary>
        ///     Gets the thumbnail url for the encapsulated <see cref="GalleryItem"/>.
        /// </summary>
        /// <param name="gallery"></param>
        /// <param name="thumbnailSize"></param>
        /// <returns></returns>
        public async Task<string> GetThumbnailUrl(IImageEndpoint gallery, ThumbnailSize thumbnailSize)
        {
            string id, mime;
            if (item is GalleryImage)
            {
                id = image.Id;
                mime = image.Type;
            }
            else
            {
                try
                {
                    var cover = await gallery.GetImageAsync(album.Cover);
                    id = cover.Id;
                    mime = cover.Type;
                }
                catch (ImgurException)
                {
                    return null;
                }
            }

            return ImgurHelper.CreateThumbnailUrl(id, thumbnailSize, mime);
        }
    }
}
