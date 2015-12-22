using System;
using System.Collections.Generic;
using Imgur.API.Enums;
using Imgur.API.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    ///     Represents an images comment.
    /// </summary>
    public class Comment : IComment
    {
        /// <summary>
        ///     The ID for the comment.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     The Id of the image that the comment is for.
        /// </summary>
        [JsonProperty("image_id")]
        public string ImageId { get; set; }

        /// <summary>
        ///     The comment itself.
        /// </summary>
        [JsonProperty("comment")]
        public string CommentText { get; set; }

        /// <summary>
        ///     Username of the author of the comment.
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        ///     The account ID for the author.
        /// </summary>
        [JsonProperty("author_id")]
        public int AuthorId { get; set; }

        /// <summary>
        ///     If this comment was done to an album.
        /// </summary>
        [JsonProperty("on_album")]
        public bool OnAlbum { get; set; }

        /// <summary>
        ///     The ID of the album cover image, this is what should be displayed for album comments.
        /// </summary>
        [JsonProperty("album_cover")]
        public string AlbumCover { get; set; }

        /// <summary>
        ///     Number of upvotes for the comment.
        /// </summary>
        [JsonProperty("ups")]
        public int? Ups { get; set; }

        /// <summary>
        ///     The number of downvotes for the comment.
        /// </summary>
        [JsonProperty("downs")]
        public int? Downs { get; set; }

        /// <summary>
        ///     The platform the comment was made on (Android, Desktop etc).
        /// </summary>
        [JsonProperty("platform")]
        public string Platform { get; set; }

        /// <summary>
        ///     The number of upvotes - downvotes.
        /// </summary>
        [JsonProperty("points")]
        public float Points { get; set; }

        /// <summary>
        ///     Utc timestamp of creation, converted from epoch time.
        /// </summary>
        [JsonProperty("datetime")]
        [JsonConverter(typeof (EpochTimeConverter))]
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        ///     If this is a reply, this will be the value of the CommentId for the caption this a reply for.
        /// </summary>
        [JsonProperty("parent_id")]
        public int? ParentId { get; set; }

        /// <summary>
        ///     Marked true if this caption has been deleted.
        /// </summary>
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        ///     The current user's vote on the comment. null if not signed in or if the user hasn't voted on it.
        /// </summary>
        [JsonProperty("vote")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Vote? Vote { get; set; }

        /// <summary>
        ///     All of the replies for this comment. If there are no replies to the comment then this is an empty set.
        /// </summary>
        [JsonProperty("children")]
        [JsonConverter(typeof(TypeConverter<ICollection<Comment>>))]
        public ICollection<IComment> Children { get; set; }
    }
}