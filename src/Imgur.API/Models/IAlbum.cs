using Imgur.API.Enums;
using System;
using System.Collections.Generic;

namespace Imgur.API.Models
{
    /// <summary>
    /// Description of IAlbum.
    /// </summary>
    public interface IAlbum : IAlbumImageBase
	{
        /// <summary>
        ///     The width, in pixels, of the album cover image.
        /// </summary>
       	string Cover { get; set; }

        /// <summary>
        ///     The width, in pixels, of the album cover image.
        /// </summary>
        int? CoverWidth { get; set; }

        /// <summary>
        ///     The height, in pixels, of the album cover image.
        /// </summary>
        int? CoverHeight { get; set; }

        /// <summary>
        ///     The privacy level of the album, you can only view public if not logged in as album owner.
        /// </summary>
        AlbumPrivacy? Privacy { get; set; }

        /// <summary>
        ///     An array of all the images in the album (only available when requesting the direct album).
        /// </summary>
        AlbumLayout? Layout { get; set;}

        /// <summary>
        ///     Order number of the album on the user's album page (defaults to 0 if their albums haven't been reordered).
        /// </summary>
        int Order { get; set; }

        /// <summary>
        ///     The total number of images in the album.
        /// </summary>
        int ImagesCount { get; set; }

        /// <summary>
        ///     An array of all the images in the album (only available when requesting the direct album).
        /// </summary>
        ICollection<IImage> Images { get; set; }

        /// <summary>
        /// The account username or null if it's anonymous.
        /// </summary>
        string AccountUrl { get; set; }

        /// <summary>
        /// The account ID or null if it's anonymous.
        /// </summary>
        string AccountId { get; set; }
    }
}
