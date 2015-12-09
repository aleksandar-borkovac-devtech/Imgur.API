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
	/// Description of Reporting.
	/// </summary>
	public enum Reporting
	{
		DoesNotBelongOnImgur = 1,
		Spam = 2,
		Abusive = 3,
		MatureContentNotMarked = 4,
		Pornography = 5
	}
}
