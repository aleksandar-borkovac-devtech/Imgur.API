/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 2:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.API.Models
{
	/// <summary>
	/// Description of IImage.
	/// </summary>
	public interface IImage : IAlbumImageBase
	{
        /// <summary>
        /// Is the image animated.
        /// </summary>
		bool Animated {get;set;}

        /// <summary>
        /// The width of the image in pixels.
        /// </summary>
        int Width {get;set;}

        /// <summary>
        /// The height of the image in pixels.
        /// </summary>
        int Height {get;set;}

        /// <summary>
        /// The size of the image in bytes.
        /// </summary>
        int Size {get;set;}

        /// <summary>
        /// Image MIME type.
        /// </summary>
        string Type {get;set;}

        /// <summary>
        /// Bandwidth consumed by the image in bytes.
        /// </summary>
        long Bandwidth {get;set;}

        /// <summary>
        /// OPTIONAL, the original filename, if you're logged in as the image owner.
        /// </summary>
        string Name {get;set;}

        /// <summary>
        /// OPTIONAL, The .gifv link. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        string Gifv {get;set;}

        /// <summary>
        /// OPTIONAL, The direct link to the .mp4. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        string Mp4 {get;set;}

        /// <summary>
        /// OPTIONAL, The direct link to the .webm. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        string Webm {get;set;}

        /// <summary>
        /// OPTIONAL, Whether the image has a looping animation. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        bool? Looping {get;set;}

        /// <summary>
        /// The current user's vote on the album. null if not signed in, if the user hasn't voted on it, or if not submitted to the gallery.
        /// </summary>
        string Vote {get;set;}
	}
}