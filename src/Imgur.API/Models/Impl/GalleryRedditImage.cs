/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 4:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    /// Description of GalleryRedditImage.
    /// </summary>
    public class GalleryRedditImage : GalleryImage, IRedditItem
    {
        /// <summary>
        /// Link to reddit comments url.
        /// </summary>
        [JsonProperty("reddit_comments")]
        public string RedditCommentsUrl { get; set; }
    }
}