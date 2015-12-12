/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 3:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    /// Description of TagVote.
    /// </summary>
    public class TagVote : ITagVote
    {
        /// <summary>
        /// Number of upvotes.
        /// </summary>
		[JsonProperty("ups")]
        public int Ups { get; set; }

        /// <summary>
        /// Number of downvotes.
        /// </summary>
		[JsonProperty("downs")]
        public int Downs { get; set; }

        /// <summary>
        /// Name of the tag. 
        /// </summary>
		[JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Author of the tag.
        /// </summary>
		[JsonProperty("author")]
        public string Author { get; set; }
    }
}