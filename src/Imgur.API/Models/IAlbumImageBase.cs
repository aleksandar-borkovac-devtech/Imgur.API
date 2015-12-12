/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 2:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.API.Models
{
	/// <summary>
	/// Description of IAlbumImageBase.
	/// </summary>
	public interface IAlbumImageBase : IDataModel
	{
		string Id {get;set;}
		
		string Title {get;set;}
		
		string Description {get;set;}
		
		DateTimeOffset DateTime {get;set;}

		string Link {get;set;}
		
		string DeleteHash {get;set;}
		
		bool? Nsfw {get;set;}
		
		string Section {get;set;}
		
		bool Favorite {get;set;}
		
		int Views {get;set;}
	}
}
