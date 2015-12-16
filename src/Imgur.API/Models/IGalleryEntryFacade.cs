using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Models
{
    public interface IGalleryEntryFacade : IGalleryAlbumImageBase, IAlbum, IImage
    {
        string ThumbnailUrl { get; }
    }
}
