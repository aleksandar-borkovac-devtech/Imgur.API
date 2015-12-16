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

namespace Imgur.API.Models.Impl
{
    /// <summary>
    /// A facade that encapsulates either an <see cref="GalleryImage"/> or an <see cref="GalleryAlbum"/>, meant unify their usage.
    /// </summary>
    public class GalleryEntryFacade : IGalleryEntryFacade
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
        ///     Upvotes for the image.
        /// </summary>
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

        /// <summary>
        ///     Number of downvotes for the image.
        /// </summary>
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

        /// <summary>
        ///     Imgur popularity score.
        /// </summary>
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

        /// <summary>
        ///     Number of comments on the gallery album.
        /// </summary>
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

        /// <summary>
        ///     Up to 10 top level comments, sorted by "best".
        /// </summary>
        public IComment[] CommentPreview
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

        /// <summary>
        ///     Topic of the gallery album.
        /// </summary>
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

        /// <summary>
        ///     Topic ID of the gallery album.
        /// </summary>
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

        /// <summary>
        ///     The current user's vote on the album. null if not signed in or if the user hasn't voted on it.
        /// </summary>
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

        /// <summary>
        ///     The username of the account that uploaded it, or null.
        /// </summary>
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

        /// <summary>
        ///     The account ID for the uploader, or null.
        /// </summary>
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

        /// <summary>
        /// The ID for the image or album.
        /// </summary>
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

        /// <summary>
        /// The title of the image or album.
        /// </summary>
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

        /// <summary>
        /// Description of the image or album.
        /// </summary>
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

        /// <summary>
        /// Time uploaded or added to gallery.
        /// </summary>
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

        /// <summary>
        /// The direct link to the the image or album.
        /// 
        /// Note: if fetching an animated GIF that was over 20MB in original size, a .gif thumbnail will be returned
        /// </summary>
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

        /// <summary>
        /// OPTIONAL, the deletehash, if you're logged in as the image owner.
        /// </summary>
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

        /// <summary>
        /// Indicates if the image has been marked as nsfw or not. Defaults to null if information is not available.
        /// </summary>
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

        /// <summary>
        /// If the image has been categorized by our backend then this will contain the section the image belongs in. (funny, cats, adviceanimals, wtf, etc)
        /// </summary>
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

        /// <summary>
        /// Indicates if the current user favorited the image. Defaults to false if not signed in.
        /// </summary>
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

        /// <summary>
        /// The number of image views.
        /// </summary>
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

        /// <summary>
        ///     The ID of the album cover image.
        /// </summary>
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

        /// <summary>
        ///     The width, in pixels, of the album cover image.
        /// </summary>
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

        /// <summary>
        ///     The height, in pixels, of the album cover image.
        /// </summary>
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

        /// <summary>
        ///     The privacy level of the album, you can only view public if not logged in as album owner.
        /// </summary>
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

        /// <summary>
        ///     The view layout of the album.
        /// </summary>
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

        /// <summary>
        ///     Order number of the album on the user's album page (defaults to 0 if their albums haven't been reordered).
        /// </summary>
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

        /// <summary>
        ///     The total number of images in the album.
        /// </summary>
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

        /// <summary>
        ///     An array of all the images in the album (only available when requesting the direct album).
        /// </summary>
        public IImage[] Images
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

        /// <summary>
        /// Is the image animated.
        /// </summary>
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

        /// <summary>
        /// The width of the image in pixels.
        /// </summary>
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

        /// <summary>
        /// The height of the image in pixels.
        /// </summary>
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

        /// <summary>
        /// The size of the image in bytes.
        /// </summary>
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

        /// <summary>
        /// Image MIME type.
        /// </summary>
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

        /// <summary>
        /// Bandwidth consumed by the image in bytes.
        /// </summary>
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

        /// <summary>
        /// OPTIONAL, the original filename, if you're logged in as the image owner.
        /// </summary>
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

        /// <summary>
        /// OPTIONAL, The .gifv link. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
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

        /// <summary>
        /// OPTIONAL, The direct link to the .mp4. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
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

        /// <summary>
        /// OPTIONAL, The direct link to the .webm. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
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

        /// <summary>
        /// OPTIONAL, Whether the image has a looping animation. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
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
        /// <param name="thumbnailSize"></param>
        /// <returns></returns>
        public string GetThumbnailUrl(ThumbnailSize thumbnailSize)
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

        /// <summary>
        /// The thumbnail size to use in the <see cref="ThumbnailUrl"/> property.
        /// </summary>
        public static ThumbnailSize ThumbnailSize { get; set; } = ThumbnailSize.SmallSquare;

        /// <summary>
        /// Fetches a thumbnail for the contained gallery item.
        /// </summary>
        public string ThumbnailUrl
        {
            get
            {
                return GetThumbnailUrl(ThumbnailSize);
            }
        }

        public string CoverUrl
        {
            get
            {
                return string.Format("http://i.imgur.com/{0}.{1}", Cover, "png");
            }
        }
    }
}
