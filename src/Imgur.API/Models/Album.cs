﻿/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 3:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.Windows.Models
{
	/// <summary>
	/// Description of Album.
	/// </summary>
	public class Album : AlbumImageBase, IAlbum
	{
        /// <summary>
        ///     The ID of the album cover image.
        /// </summary>
        public string Cover { get; set; }

        /// <summary>
        ///     The width, in pixels, of the album cover image.
        /// </summary>
        [JsonProperty("cover_width")]
        public int? CoverWidth { get; set; }

        /// <summary>
        ///     The height, in pixels, of the album cover image.
        /// </summary>
        [JsonProperty("cover_height")]
        public int? CoverHeight { get; set; }

        /// <summary>
        ///     The account username or null if it's anonymous.
        /// </summary>
        [JsonProperty("account_url")]
        public string AccountUrl { get; set; }

        /// <summary>
        ///     The account ID or null if it's anonymous.
        /// </summary>
        [JsonProperty("account_id")]
        public int? AccountId { get; set; }

        /// <summary>
        ///     The privacy level of the album, you can only view public if not logged in as album owner.
        /// </summary>
        public AlbumPrivacy Privacy { get; set; }

        /// <summary>
        ///     The view layout of the album.
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        ///     Order number of the album on the user's album page (defaults to 0 if their albums haven't been reordered).
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        ///     The total number of images in the album.
        /// </summary>
        [JsonProperty("images_count")]
        public int ImagesCount { get; set; }

        /// <summary>
        ///     An array of all the images in the album (only available when requesting the direct album).
        /// </summary>
        [JsonConverter(typeof (EnumerableConverter<Image>))]
        public IEnumerable<IImage> Images { get; set; } = new List<IImage>();
	}
}