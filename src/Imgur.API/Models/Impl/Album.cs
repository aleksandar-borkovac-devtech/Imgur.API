using System;
using System.Collections.Generic;
using Imgur.API.Enums;
using Imgur.API.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Imgur.API.Models.Impl
{
	/// <summary>
	/// Description of Album.
	/// </summary>
	public class Album : AlbumImageBase, IAlbum
	{
        /// <summary>
        ///     The ID of the album cover image.
        /// </summary>
        [JsonProperty("cover")]
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
        public string AccountId { get; set; }

        /// <summary>
        ///     The privacy level of the album, you can only view public if not logged in as album owner.
        /// </summary>
        [JsonProperty("privacy")]
        [JsonConverter(typeof(AlbumPrivacyConverter))]
        public AlbumPrivacy? Privacy { get; set; }

        /// <summary>
        ///     The view layout of the album.
        /// </summary>
        [JsonProperty("layout")]
        [JsonConverter(typeof(AlbumLayoutConverter))]
        public AlbumLayout? Layout { get; set; }

        /// <summary>
        ///     Order number of the album on the user's album page (defaults to 0 if their albums haven't been reordered).
        /// </summary>
        [JsonProperty("order")]
        public int Order { get; set; }

        /// <summary>
        ///     The total number of images in the album.
        /// </summary>
        [JsonProperty("images_count")]
        public int ImagesCount { get; set; }

        /// <summary>
        ///     An array of all the images in the album (only available when requesting the direct album).
        /// </summary>
        [JsonProperty("images")]
        [JsonConverter(typeof(TypeConverter<ICollection<Image>>))]
        public ICollection<IImage> Images { get; set; }
	}
}