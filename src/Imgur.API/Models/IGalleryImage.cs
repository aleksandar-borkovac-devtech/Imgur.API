using System;
using System.Collections.Generic;

namespace Imgur.API.Models
{
    /// <summary>
    ///     The data model formatted for gallery images.
    /// </summary>
    public interface IGalleryImage : IGalleryAlbumImageBase, IImage
    {
    }
}