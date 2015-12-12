/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 2:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.API.Models
{
    /// <summary>
    /// Common values between albums and images.
    /// </summary>
    public interface IAlbumImageBase : IDataModel
    {
        /// <summary>
        /// The ID for the image or album.
        /// </summary>
		string Id { get; set; }

        /// <summary>
        /// The title of the image or album.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Description of the image or album.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Time uploaded or added to gallery.
        /// </summary>
        DateTimeOffset DateTime { get; set; }

        /// <summary>
        /// The direct link to the the image or album.
        /// 
        /// Note: if fetching an animated GIF that was over 20MB in original size, a .gif thumbnail will be returned
        /// </summary>
		string Link { get; set; }

        /// <summary>
        /// OPTIONAL, the deletehash, if you're logged in as the image owner.
        /// </summary>
        string DeleteHash { get; set; }

        /// <summary>
        /// Indicates if the image has been marked as nsfw or not. Defaults to null if information is not available.
        /// </summary>
        bool? Nsfw { get; set; }

        /// <summary>
        /// If the image has been categorized by our backend then this will contain the section the image belongs in. (funny, cats, adviceanimals, wtf, etc)
        /// </summary>
        string Section { get; set; }

        /// <summary>
        /// Indicates if the current user favorited the image. Defaults to false if not signed in.
        /// </summary>
        bool Favorite { get; set; }

        /// <summary>
        /// The number of image views.
        /// </summary>
        int Views { get; set; }
    }
}