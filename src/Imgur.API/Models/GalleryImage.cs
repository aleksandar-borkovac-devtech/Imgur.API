/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 2:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;
using System;

namespace Imgur.API.Models
{
	/// <summary>
	/// Description of GalleryImage.
	/// </summary>
	public class GalleryImage : GalleryAlbumImageBase, IImage
	{
        [JsonProperty("name")]
		public string Name {get;set;}
		
        /// <summary>
        ///     OPTIONAL, The .gifv link. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        [JsonProperty("gifv")]
        public string Gifv { get; set; }

        /// <summary>
        ///     OPTIONAL, The direct link to the .mp4. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        [JsonProperty("mp4")]
        public string Mp4 { get; set; }

        /// <summary>
        ///     OPTIONAL, The direct link to the .webm. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        [JsonProperty("webm")]
        public string Webm { get; set; }

        /// <summary>
        ///     OPTIONAL, Whether the image has a looping animation. Only available if the image is animated and type is
        ///     'image/gif'.
        /// </summary>
        [JsonProperty("looping")]
        public bool? Looping { get; set; }

        /// <summary>
        ///     Is the image animated.
        /// </summary>
        [JsonProperty("animated")]
        public bool Animated { get; set; }

        /// <summary>
        ///     The width of the image in pixels.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        ///     The height of the image in pixels.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        ///     The size of the image in bytes.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        ///     Image MIME type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Bandwidth consumed by the image in bytes.
        /// </summary>
        [JsonProperty("bandwidth")]
        public long Bandwidth { get; set; }
	}
}
