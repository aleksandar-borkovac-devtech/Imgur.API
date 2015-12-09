/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 2:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.Windows.Models
{
	/// <summary>
	/// Description of AlbumImageBase.
	/// </summary>
	public class AlbumImageBase : IAlbumImageBase
	{
		public AlbumImageBase()
		{
		}
		
        /// <summary>
        ///     The ID for the album.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The title of the album in the gallery.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     The description of the album in the gallery.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Utc timestamp of when the album was inserted into the gallery, converted from epoch time.
        /// </summary>
        [JsonConverter(typeof (EpochTimeConverter))]
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        ///     The number of album views.
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        ///     The URL link to the album.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        ///     Indicates if the current user favorited the image. Defaults to false if not signed in.
        /// </summary>
        public bool Favorite { get; set; }

        /// <summary>
        ///     Indicates if the image has been marked as nsfw or not. Defaults to null if information is not available.
        /// </summary>
        public bool? Nsfw { get; set; }

        /// <summary>
        ///     If the image has been categorized then this will contain the section the image belongs in. (funny, cats,
        ///     adviceanimals, wtf, etc)
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        ///     OPTIONAL, the deletehash, if you're logged in as the album owner.
        /// </summary>
        public string? DeleteHash { get; set; }
	}
}
