/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 2:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Imgur.API.JsonConverters;
using Newtonsoft.Json;
using System;

namespace Imgur.API.Models.Impl
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
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     The title of the album in the gallery.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///     The description of the album in the gallery.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Utc timestamp of when the album was inserted into the gallery, converted from epoch time.
        /// </summary>
        [JsonProperty("datetime")]
        [JsonConverter(typeof (EpochTimeConverter))]
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        ///     The number of album views.
        /// </summary>
        [JsonProperty("views")]
        public int Views { get; set; }

        /// <summary>
        ///     The URL link to the album.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        ///     Indicates if the current user favorited the image. Defaults to false if not signed in.
        /// </summary>
        [JsonProperty("favorite")]
        public bool Favorite { get; set; }

        /// <summary>
        ///     Indicates if the image has been marked as nsfw or not. Defaults to null if information is not available.
        /// </summary>
        [JsonProperty("nsfw")]
        public bool? Nsfw { get; set; }

        /// <summary>
        ///     If the image has been categorized then this will contain the section the image belongs in. (funny, cats,
        ///     adviceanimals, wtf, etc)
        /// </summary>
        [JsonProperty("section")]
        public string Section { get; set; }

        /// <summary>
        ///     OPTIONAL, the deletehash, if you're logged in as the album owner.
        /// </summary>
        [JsonProperty("deletehash")]
        public string DeleteHash { get; set; }
    }
}
