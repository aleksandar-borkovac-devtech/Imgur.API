/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 2:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.Windows.Models
{
	/// <summary>
	/// Description of IImage.
	/// </summary>
	public interface IImage : IAlbumImageBase
	{
		bool Animated {get;set;}
		
		int Width {get;set;}
		
		int Height {get;set;}
		
		int Size {get;set;}
		
		string Type {get;set;}
		
		long Bandwidth {get;set;}
		
		string Name {get;set;}
		
		string Gifv {get;set;}
		
		string Mp4{get;set;}
		
		string Webm{get;set;}
		
		bool? Looping {get;set;}
		
		string Vote {get;set;}
	}
}
