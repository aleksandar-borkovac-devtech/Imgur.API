/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 4:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.API.Models
{
	/// <summary>
	/// Description of IRedditItem.
	/// </summary>
	public interface IRedditItem
	{
        /// <summary>
        /// Link to reddit comments url.
        /// </summary>
		string RedditCommentsUrl {get;set;}
	}
}
