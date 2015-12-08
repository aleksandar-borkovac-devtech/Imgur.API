using Imgur.API.Endpoints;
using Imgur.API.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Models
{
    /// <summary>
    /// A facade that encapsulates either an <see cref="IGalleryImage"/> or an <see cref="IGalleryAlbum"/>, meant generalize dealing with them.
    /// </summary>
    public class GalleryEntryFacade
    {
        private IGalleryImage image;
        private IGalleryAlbum album;

        private IGalleryItem item;

        /// <summary>
        /// The gallery item being encapsulated.
        /// </summary>
        public IGalleryItem Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;

                if (item is IGalleryImage)
                {
                    image = value as IGalleryImage;
                    album = null;
                }
                else
                {
                    image = null;
                    album = value as IGalleryAlbum;
                }
            }
        }

        /// <summary>
        /// Initializes the facade with the given <see cref="IGalleryItem"/>.
        /// </summary>
        /// <param name="item"></param>
        public GalleryEntryFacade(IGalleryItem item)
        {
            Item = item;
        }

        /// <summary>
        ///     Gets the thumbnail url for the encapsulated <see cref="IGalleryItem"/>.
        /// </summary>
        /// <param name="gallery"></param>
        /// <param name="thumbnailSize"></param>
        /// <returns></returns>
        public async Task<string> GetThumbnailUrl(IImageEndpoint gallery, ThumbnailSize thumbnailSize)
        {
            string id, mime;
            if (image is IGalleryImage)
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
