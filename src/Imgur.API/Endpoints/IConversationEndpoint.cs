/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 11-12-2015
 * Time: 12:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading.Tasks;
using Imgur.API.Models;

namespace Imgur.API.Endpoints
{
	/// <summary>
	/// Description of IConversationEndpoint.
	/// </summary>
	public interface IConversationEndpoint
	{
		Task<IConversation[]> GetConversationListAsync();
		
		Task<IConversation> GetConversationAsync(string id, uint page = 1, uint offset=0);
		
		Task<object> SendMessageAsync(string recipient, string body);
		
		Task<object> DeleteConversation(string id);
		
		Task<object> ReportSenderAsync(string username);
		
		Task<object> BlockSenderAsync(string username);
	}
}
