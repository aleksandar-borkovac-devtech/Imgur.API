/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 4:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;

namespace Imgur.API.Models.Impl
{
	/// <summary>
	/// Description of Vote.
	/// </summary>
	public class Votes : IVotes
	{
        /// <summary>
        /// Number of upvotes.
        /// </summary>
		[JsonProperty("ups")]
		public int Ups {get;set;}

        /// <summary>
        /// Number of downvotes.
        /// </summary>
		[JsonProperty("downs")]
		public int Downs {get;set;}
	}
}
