/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 4:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;

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
        public string[] Tags { get; set; }

        /// <summary>
        /// The total number of gallery items in the custom gallery.
        /// </summary>
        [JsonProperty("item_count")]
        public int ItemCount { get; set; }

        /// <summary>
        /// An array of all the gallery items in the custom gallery.
        /// </summary>
        [JsonProperty("items")]
        public IGalleryAlbumImageBase[] Items { get; set; }
    }
}
