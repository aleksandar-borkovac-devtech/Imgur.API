using System;
using System.Collections.Generic;
using Imgur.API.Enums;

namespace Imgur.API.Models
{
    /// <summary>
    ///     The data model formatted for gallery albums.
    /// </summary>
    public interface IGalleryAlbum : IGalleryAlbumImageBase, IAlbum
    {
    }
}