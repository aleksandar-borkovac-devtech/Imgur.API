using Imgur.API.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    /// This model represents a user's custom or filtered gallery.
    /// </summary>
    public class CustomGallery : ICustomGallery
    {
        /// <summary>
        /// Username of the account that created the custom gallery.
        /// </summary>
        [JsonProperty("account_url")]
        public string AccountUrl { get; set; }

        /// <summary>
        ///  The URL link to the custom gallery.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// An array of all the tag names in the custom gallery.
        /// </summary>
        [JsonProperty("tags")]
        [JsonConverter(typeof(TypeConverter<ICollection<string>>))]
        public ICollection<string> Tags { get; set; }

        /// <summary>
        /// The total number of gallery items in the custom gallery.
        /// </summary>
        [JsonProperty("item_count")]
        public int ItemCount { get; set; }

        /// <summary>
        /// An array of all the gallery items in the custom gallery.
        /// </summary>
        [JsonProperty("items")]
        [JsonConverter(typeof(TypeConverter<ICollection<IGalleryAlbumImageBase>>))]
        public ICollection<IGalleryAlbumImageBase> Items { get; set; }
    }
}
