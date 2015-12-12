using Imgur.API.Endpoints;
using Imgur.API.Enums;
using Imgur.API.Exceptions;
using Imgur.API.Models;
using Imgur.API.Models.Impl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Models
{
    /// <summary>
    /// A facade that encapsulates either an <see cref="GalleryImage"/> or an <see cref="GalleryAlbum"/>, meant unify their usage.
    /// </summary>
    public class GalleryEntryFacade : IGalleryAlbumImageBase, IAlbum, IImage
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

        public int? Ups
        {
            get
            {
                return item.Ups;
            }
            set
            {
                item.Ups = value;
            }
        }

        public int? Downs
        {
            get
            {
                return item.Downs;
            }
            set
            {
                item.Downs = value;
            }
        }

        public int? Score
        {
            get
            {
                return item.Score;
            }

            set
            {
                item.Score = value;
            }
        }

        public int? CommentCount
        {
            get
            {
                return item.CommentCount;
            }

            set
            {
                item.CommentCount = value;
            }
        }

        public IEnumerable<IComment> CommentPreview
        {
            get
            {
                return item.CommentPreview;
            }

            set
            {
                item.CommentPreview = value;
            }
        }

        public string Topic
        {
            get
            {
                return item.Topic;
            }

            set
            {
                item.Topic = value;
            }
        }

        public int? TopicId
        {
            get
            {
                return item.TopicId;
            }

            set
            {
                item.TopicId = value;
            }
        }

        public string Vote
        {
            get
            {
                return item.Vote;
            }

            set
            {
                item.Vote = value;
            }
        }

        public string AccountUrl
        {
            get
            {
                return item.AccountUrl;
            }

            set
            {
                item.AccountUrl = value;
            }
        }

        public string AccountId
        {
            get
            {
                return item.AccountId;
            }

            set
            {
                item.AccountId = value;
            }
        }

        public string Id
        {
            get
            {
                return item.Id;
            }

            set
            {
                item.Id = value;
            }
        }

        public string Title
        {
            get
            {
                return item.Title;
            }

            set
            {
                item.Title = value;
            }
        }

        public string Description
        {
            get
            {
                return item.Description;
            }

            set
            {
                item.Description = value;
            }
        }

        public DateTimeOffset DateTime
        {
            get
            {
                return item.DateTime;
            }

            set
            {
                item.DateTime = value;
            }
        }

        public string Link
        {
            get
            {
                return item.Link;
            }

            set
            {
                item.Link = value;
            }
        }

        public string DeleteHash
        {
            get
            {
                return item.DeleteHash;
            }

            set
            {
                item.DeleteHash = value;
            }
        }

        public bool? Nsfw
        {
            get
            {
                return item.Nsfw;
            }

            set
            {
                item.Nsfw = value;
            }
        }

        public string Section
        {
            get
            {
                return item.Section;
            }

            set
            {
                item.Section = value;
            }
        }

        public bool Favorite
        {
            get
            {
                return item.Favorite;
            }

            set
            {
                item.Favorite = value;
            }
        }

        public int Views
        {
            get
            {
                return item.Views;
            }

            set
            {
                item.Views = value;
            }
        }

        public string Cover
        {
            get
            {
                if (item is GalleryImage)
                    return image.Id;
                else
                    return album.Cover;
            }

            set
            {
                if (item is GalleryImage)
                    throw new InvalidOperationException("Cannot set cover for internal image.");
                else
                    album.Cover = value;
            }
        }

        public int? CoverWidth
        {
            get
            {
                if (item is GalleryImage)
                    return image.Width;
                else
                    return album.CoverWidth;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int? CoverHeight
        {
            get
            {
                if (item is GalleryImage)
                    return image.Height;
                else
                    return album.CoverHeight;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public AlbumPrivacy Privacy
        {
            get
            {
                if (item is GalleryAlbum)
                    return album.Privacy;
                else
                    return AlbumPrivacy.Public;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public AlbumLayout Layout
        {
            get
            {
                if (item is GalleryAlbum)
                    return album.Layout;
                else
                    throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Order
        {
            get
            {
                if (item is GalleryAlbum)
                    return album.Order;
                else
                    throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int ImageCount
        {
            get
            {
                if (item is GalleryAlbum)
                    return album.ImageCount;
                else
                    return 1;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<IImage> Images
        {
            get
            {
                if (item is GalleryAlbum)
                    return album.Images;
                else
                    return new IImage[] { image };
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Animated
        {
            get
            {
                if (item is GalleryAlbum)
                    return false;
                else
                    return image.Animated;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Width
        {
            get
            {
                if (item is GalleryAlbum)
                    return album.CoverWidth ?? 0;
                else
                    return image.Width;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Height
        {
            get
            {
                if (item is GalleryAlbum)
                    return album.CoverHeight ?? 0;
                else
                    return image.Height;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Size
        {
            get
            {
                if (item is GalleryAlbum)
                    throw new NotImplementedException();
                else
                    return image.Size;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Type
        {
            get
            {
                if (item is GalleryAlbum)
                    throw new NotImplementedException();
                else
                    return image.Type;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public long Bandwidth
        {
            get
            {
                if (item is GalleryAlbum)
                    throw new NotImplementedException();
                else
                    return image.Bandwidth;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                if (item is GalleryAlbum)
                    throw new NotImplementedException();
                else
                    return image.Name;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Gifv
        {
            get
            {
                if (item is GalleryAlbum)
                    throw new NotImplementedException();
                else
                    return image.Gifv;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Mp4
        {
            get
            {
                if (item is GalleryAlbum)
                    throw new NotImplementedException();
                else
                    return image.Mp4;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Webm
        {
            get
            {
                if (item is GalleryAlbum)
                    throw new NotImplementedException();
                else
                    return image.Webm;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool? Looping
        {
            get
            {
                if (item is GalleryAlbum)
                    return false;
                else
                    return image.Looping;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Initializes the facade with the given <see cref="IGalleryAlbumImageBase"/>.
        /// </summary>
        /// <param name="item"></param>
        public GalleryEntryFacade(IGalleryAlbumImageBase item)
        {
            Item = item;
        }

        /// <summary>
        ///     Gets the thumbnail url for the encapsulated <see cref="IGalleryAlbumImageBase"/>.
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
