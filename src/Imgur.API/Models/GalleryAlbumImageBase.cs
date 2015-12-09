﻿/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 2:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.Windows.Models
{
	/// <summary>
	/// Description of GalleryAlbumImageBase.
	/// </summary>
	public class GalleryAlbumImageBase : AlbumImageBase, IGalleryAlbumImageBase
	{

		public GalleryAlbumImageBase()
		{
		}

        /// <summary>
        ///     Upvotes for the image.
        /// </summary>
        public int? Ups { get; set; }

        /// <summary>
        ///     Number of downvotes for the image.
        /// </summary>
        public int? Downs { get; set; }

        /// <summary>
        ///     Imgur popularity score.
        /// </summary>
        public int? Score { get; set; }
        

        /// <summary>
        ///     Number of comments on the gallery image.
        /// </summary>
        [JsonProperty("comment_count")]
        public int? CommentCount { get; set; }

        /// <summary>
        ///     Up to 10 top level comments, sorted by "best".
        /// </summary>
        [JsonProperty("comment_preview")]
        [JsonConverter(typeof (EnumerableConverter<Comment>))]
        public IEnumerable<IComment> CommentPreview { get; set; } = new List<IComment>();

        /// <summary>
        ///     Topic of the gallery image.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        ///     Topic ID of the gallery image.
        /// </summary>
        [JsonProperty("topic_id")]
        public int? TopicId { get; set; }

        /// <summary>
        ///     The username of the account that uploaded it, or null.
        /// </summary>
        [JsonProperty("account_url")]
        public string AccountUrl { get; set; }

        /// <summary>
        ///     The account ID for the uploader, or null.
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        ///     The current user's vote on the album. null if not signed in, if the user hasn't voted on it, or if not submitted to
        ///     the gallery.
        /// </summary>
        public string Vote { get; set; }
	}
}