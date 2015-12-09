/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 2:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.Windows.Models
{
	/// <summary>
	/// Description of IGalleryAlbumImageBase.
	/// </summary>
	public interface IGalleryAlbumImageBase : IAlbumImageBase
	{
		/// <summary>
        ///     Upvotes for the image.
        /// </summary>
        int? Ups { get; set; }

        /// <summary>
        ///     Number of downvotes for the image.
        /// </summary>
        int? Downs { get; set; }

        /// <summary>
        ///     Imgur popularity score.
        /// </summary>
        int? Score { get; set; }

        /// <summary>
        ///     Number of comments on the gallery album.
        /// </summary>
        int? CommentCount { get; set; }

        /// <summary>
        ///     Up to 10 top level comments, sorted by "best".
        /// </summary>
        IEnumerable<IComment> CommentPreview { get; set; }

        /// <summary>
        ///     Topic of the gallery album.
        /// </summary>
        string Topic { get; set; }

        /// <summary>
        ///     Topic ID of the gallery album.
        /// </summary>
        int? TopicId { get; set; }
        
        string Vote{get;set;}

	}
}
