/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 2:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.Windows.Models
{
	/// <summary>
	/// Description of GalleryImage.
	/// </summary>
	public class GalleryImage : GalleryAlbumImageBase, IImage
	{
		public string Name {get;set;}
		
        /// <summary>
        ///     OPTIONAL, The .gifv link. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        public string Gifv { get; set; }

        /// <summary>
        ///     OPTIONAL, The direct link to the .mp4. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        public string Mp4 { get; set; }

        /// <summary>
        ///     OPTIONAL, The direct link to the .webm. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        public string Webm { get; set; }

        /// <summary>
        ///     OPTIONAL, Whether the image has a looping animation. Only available if the image is animated and type is
        ///     'image/gif'.
        /// </summary>
        public bool Looping { get; set; }

        /// <summary>
        ///     Is the image animated.
        /// </summary>
        public bool Animated { get; set; }

        /// <summary>
        ///     The width of the image in pixels.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        ///     The height of the image in pixels.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        ///     The size of the image in bytes.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        ///     Image MIME type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Bandwidth consumed by the image in bytes.
        /// </summary>
        public long Bandwidth { get; set; }
	}
}
