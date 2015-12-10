/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 4:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.API.Models.Impl
{
	/// <summary>
	/// Description of Tag.
	/// </summary>
	public class Tag : ITag
	{
		public Tag()
		{
		}

		#region ITag implementation
		
		[JsonProperty("name")]
		public string Name {get;set;}

		[JsonProperty("followers")]
		public int Followers {get;set;}

		[JsonProperty("total_items")]
		public int TotalItems {get;set;}

		[JsonProperty("following")]
		public bool? Following {get;set;}

		[JsonProperty("items")]
		public IGalleryAlbumImageBase[] Items {get;set;}
		
		#endregion
	}
}
