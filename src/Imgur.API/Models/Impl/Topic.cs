/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 3:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.API.Models.Impl
{
	/// <summary>
	/// Description of Topic.
	/// </summary>
	public class Topic : ITopic
	{
		public Topic()
		{
		}

		#region ITopic implementation

		[JsonProperty("id")]
		public int Id {get;set;}

		[JsonProperty("name")]
		public string Name {get;set;}

		[JsonProperty("description")]
		public string Description { get;set;}

		[JsonProperty("css")]
		public string Css {get;set;}

		[JsonProperty("Ephemeral")]
		public bool Ephemeral{get;set;}

		#endregion
	}
}
