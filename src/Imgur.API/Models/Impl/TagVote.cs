/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 3:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.API.Models.Impl
{
	/// <summary>
	/// Description of TagVote.
	/// </summary>
	public class TagVote : ITagVote
	{
		public TagVote()
		{
		}

		#region ITagVote implementation

		[JsonProperty("ups")]
		public int Ups {get;set;}

		[JsonProperty("downs")]
		public int Downs {get;set;}

		[JsonProperty("name")]
		public string Name {get;set;}

		[JsonProperty("author")]
		public string Author {get;set;}
		#endregion
	}
}
