/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 4:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;
using System;

namespace Imgur.API.Models.Impl
{
	/// <summary>
	/// Description of CustomGallery.
	/// </summary>
	public class CustomGallery : ICustomGallery
	{
		public CustomGallery()
		{
		}

		#region ICustomGallery implementation

		[JsonProperty("account_url")]
		public string AccountUrl {get;set;}

		[JsonProperty("link")]
		public string Link {get;set;}

		[JsonProperty("tags")]
		public string[] Tags {get;set;}

		[JsonProperty("item_count")]
		public int ItemCount {get;set;}

		[JsonProperty("items")]
		public IGalleryAlbumImageBase[] Items {get;set;}

		#endregion
	}
}
