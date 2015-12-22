using Newtonsoft.Json;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    /// Description of GalleryRedditImage.
    /// </summary>
    public class GalleryRedditImage : GalleryImage, IGalleryRedditImage
    {
        /// <summary>
        /// Link to reddit comments url.
        /// </summary>
        [JsonProperty("reddit_comments")]
        public string RedditCommentsUrl { get; set; }
    }
}