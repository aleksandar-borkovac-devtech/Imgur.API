/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 09-12-2015
 * Time: 4:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Imgur.API.Enums
{
	/// <summary>
	/// Reasons to report a gallery item.
	/// </summary>
	public enum Reporting
	{
        /// <summary>
        /// The content does not belong on imgur.
        /// </summary>
		DoesNotBelongOnImgur = 1,

        /// <summary>
        /// The content is spam.
        /// </summary>
		Spam = 2,

        /// <summary>
        /// The content is abusive.
        /// </summary>
		Abusive = 3,

        /// <summary>
        /// The content is mature, but not marked as such.
        /// </summary>
		MatureContentNotMarked = 4,

        /// <summary>
        /// The content is pornography.
        /// </summary>
		Pornography = 5
	}
}
