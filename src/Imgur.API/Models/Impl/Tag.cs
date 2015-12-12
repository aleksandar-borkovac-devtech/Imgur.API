/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 4:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;
using System;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    /// Description of Tag.
    /// </summary>
    public class Tag : ITag
    {
        /// <summary>
        ///  Name of the tag. 
        /// </summary>
		[JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///  Number of followers for the tag. 
        /// </summary>
        [JsonProperty("followers")]
        public int Followers { get; set; }

        /// <summary>
        /// Total number of gallery items for the tag.
        /// </summary>
        [JsonProperty("total_items")]
        public int TotalItems { get; set; }

        /// <summary>
        /// OPTIONAL, boolean representing whether or not the user is following the tag in their custom gallery
        /// </summary>
        [JsonProperty("following")]
        public bool? Following { get; set; }

        /// <summary>
        /// Gallery items with current tag.
        /// </summary>
        [JsonProperty("items")]
        public IGalleryAlbumImageBase[] Items { get; set; }
    }
}
