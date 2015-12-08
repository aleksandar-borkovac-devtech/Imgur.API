using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Models
{
    /// <summary>
    /// Contains various helper methods, mostly for converting imgur enumerations to strings.
    /// </summary>
    public static class ImgurHelper
    {
        /// <summary>
        /// Converts a <see cref="ThumbnailSize"/> to string.
        /// </summary>
        /// <param name="sz"></param>
        /// <returns></returns>
        public static string ThumbnailSizeToURIString(ThumbnailSize sz)
        {
            switch (sz)
            {
                case ThumbnailSize.BigSquare: return "b";
                case ThumbnailSize.Huge: return "h";
                case ThumbnailSize.Large: return "l";
                case ThumbnailSize.Medium: return "m";
                case ThumbnailSize.Small: return "t";
                case ThumbnailSize.SmallSquare: return "s";
                default:
                    throw new Exception("Invalid ThumbnailSize!");
            }
        }

        /// <summary>
        /// Generates a thumbnail url.
        /// </summary>
        /// <param name="imageID"></param>
        /// <param name="thumbnailSize"></param>
        /// <param name="mime"></param>
        /// <returns></returns>
        public static string CreateThumbnailUrl(string imageID, ThumbnailSize thumbnailSize, string mime)
        {
            return string.Format("http://i.imgur.com/{0}{1}.{2}", imageID, ThumbnailSizeToURIString(thumbnailSize), MimeToExtension(mime));
        }

        /// <summary>
        /// Converts a MIME to a file extension.
        /// </summary>
        /// <param name="mime"></param>
        /// <returns></returns>
        public static string MimeToExtension(string mime)
        {
            string extension = "jpg";
            if (mime.Contains("png"))
            {
                extension = "png";
            }
            else if (mime.Contains("jpg") || mime.Contains("jpeg"))
            {
                extension = "jpg";
            }
            else if (mime.Contains("gif"))
            {
                extension = "gif";
            }

            return extension;
        }
    }
}
