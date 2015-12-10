/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 4:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.API.Models.Impl
{
	/// <summary>
	/// Description of MemeMetadata.
	/// </summary>
	public class MemeMetaData : IMemeMetaData
	{
		public MemeMetaData()
		{
		}

		#region IMemeMetaData implementation

		[JsonProperty("meme_name")]
		public string MemeName {get;set;}

		[JsonProperty("top_text")]
		public string TopText {get;set;}

		[JsonProperty("bottom_text")]
		public string BottomText {get;set;}

		[JsonProperty("bg_image")]
		public string BgImage {get;set;}

		#endregion
	}
}
