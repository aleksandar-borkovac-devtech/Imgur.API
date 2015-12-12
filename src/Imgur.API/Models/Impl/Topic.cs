/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 3:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;

namespace Imgur.API.Models.Impl
{
	/// <summary>
	/// Description of Topic.
	/// </summary>
	public class Topic : ITopic
	{
        /// <summary>
        ///  ID of the topic. 
        /// </summary>
		[JsonProperty("id")]
		public int Id {get;set;}

        /// <summary>
        /// Topic name.
        /// </summary>
		[JsonProperty("name")]
		public string Name {get;set;}

        /// <summary>
        /// Description of the topic.
        /// </summary>
		[JsonProperty("description")]
		public string Description { get;set;}

        /// <summary>
        /// CSS class used on website to style the ephemeral topic.
        /// </summary>
		[JsonProperty("css")]
		public string Css {get;set;}

        /// <summary>
        /// Whether it is an ephemeral (e.g. current events) topic.
        /// </summary>
		[JsonProperty("Ephemeral")]
		public bool Ephemeral{get;set;}
	}
}
