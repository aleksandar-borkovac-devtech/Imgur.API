﻿using System;
using System.Collections.Generic;

namespace Imgur.API.Models
{
    /// <summary>
    ///     The data model formatted for gallery images.
    /// </summary>
    public interface IGalleryImage : IGalleryItem
    {
        /// <summary>
        ///     The account ID for the uploader, or null.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        ///     The username of the account that uploaded it, or null.
        /// </summary>
        string AccountUrl { get; set; }

        /// <summary>
        ///     Is the image animated.
        /// </summary>
        bool Animated { get; set; }

        /// <summary>
        ///     Bandwidth consumed by the image in bytes.
        /// </summary>
        long Bandwidth { get; set; }

        /// <summary>
        ///     Number of comments on the gallery image.
        /// </summary>
        int? CommentCount { get; set; }

        /// <summary>
        ///     Up to 10 top level comments, sorted by "best".
        /// </summary>
        IEnumerable<IComment> CommentPreview { get; set; }

        /// <summary>
        ///     Utc timestamp of when the image was inserted into the gallery, converted from epoch time.
        /// </summary>
        DateTimeOffset DateTime { get; set; }

        /// <summary>
        ///     OPTIONAL, the deletehash, if you're logged in as the image owner.
        /// </summary>
        string DeleteHash { get; set; }

        /// <summary>
        ///     Description of the image.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///     Number of downvotes for the image.
        /// </summary>
        int? Downs { get; set; }

        /// <summary>
        ///     Indicates if the current user favorited the image. Defaults to false if not signed in.
        /// </summary>
        bool? Favorite { get; set; }

        /// <summary>
        ///     OPTIONAL, The .gifv link. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        string Gifv { get; set; }

        /// <summary>
        ///     The height of the image in pixels.
        /// </summary>
        int Height { get; set; }

        /// <summary>
        ///     The ID for the image.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        ///     The direct link to the the image. (Note: if fetching an animated GIF that was over 20MB in original size, a .gif
        ///     thumbnail will be returned)
        /// </summary>
        string Link { get; set; }

        /// <summary>
        ///     OPTIONAL, Whether the image has a looping animation. Only available if the image is animated and type is
        ///     'image/gif'.
        /// </summary>
        bool Looping { get; set; }

        /// <summary>
        ///     OPTIONAL, The direct link to the .mp4. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        string Mp4 { get; set; }

        /// <summary>
        ///     Indicates if the image has been marked as nsfw or not. Defaults to null if information is not available.
        /// </summary>
        bool? Nsfw { get; set; }

        /// <summary>
        ///     Imgur popularity score.
        /// </summary>
        int? Score { get; set; }

        /// <summary>
        ///     If the image has been categorized then this will contain the section the image belongs in. (funny, cats,
        ///     adviceanimals, wtf, etc)
        /// </summary>
        string Section { get; set; }

        /// <summary>
        ///     The size of the image in bytes.
        /// </summary>
        int Size { get; set; }

        /// <summary>
        ///     The title of the image.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        ///     Topic of the gallery image.
        /// </summary>
        string Topic { get; set; }

        /// <summary>
        ///     Topic ID of the gallery image.
        /// </summary>
        int? TopicId { get; set; }

        /// <summary>
        ///     Image MIME type.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        ///     Upvotes for the image.
        /// </summary>
        int? Ups { get; set; }

        /// <summary>
        ///     The size of the image in bytes.
        /// </summary>
        int Views { get; set; }

        /// <summary>
        ///     The current user's vote on the album. null if not signed in, if the user hasn't voted on it, or if not submitted to
        ///     the gallery.
        /// </summary>
        string Vote { get; set; }

        /// <summary>
        ///     OPTIONAL, The direct link to the .webm. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        string Webm { get; set; }

        /// <summary>
        ///     The width of the image in pixels.
        /// </summary>
        int Width { get; set; }
    }
}