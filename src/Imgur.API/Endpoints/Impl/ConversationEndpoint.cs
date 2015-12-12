/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 11-12-2015
 * Time: 12:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading.Tasks;
using Imgur.API.Models;
using System.Net.Http;

namespace Imgur.API.Endpoints.Impl
{
	/// <summary>
	/// Description of ConversationEndpoint.
	/// </summary>
	public class ConversationEndpoint : EndpointBase, IConversationEndpoint
	{
		private const string blockSenderUrl = "conversation/block/{0}";
		private const string reportSenderUrl = "conversation/report/{0}";
		private const string sendMessageUrl = "conversation/{0}";
		private const string deleteConversationUrl = "conversation/{0}";
		private const string getConversationUrl = "conversations/{0}/{1}/{2}";
		private const string getConversationsListUrl = "conversations";
		
		public ConversationEndpoint()
		{
		}

		#region IConversationEndpoint implementation

		public async Task<IConversation[]> GetConversationListAsync()
		{
			var endpointUrl = string.Concat(GetEndpointBaseUrl(), getConversationsListUrl);
			
			var result = await MakeEndpointRequestAsync<IConversation[]>(HttpMethod.Get, endpointUrl);
			return result;
		}

		public async Task<IConversation> GetConversationAsync(string id, uint page = 1u, uint offset = 0u)
		{
			if(string.IsNullOrEmpty(id))
				throw new ArgumentNullException(nameof(id));
			
			var endpointUrl = string.Concat(GetEndpointBaseUrl(), getConversationUrl);
			endpointUrl = string.Format(endpointUrl, id, page, offset);
			
			var result = await MakeEndpointRequestAsync<IConversation>(HttpMethod.Get, endpointUrl);
			return result;
		}

		public async Task<object> SendMessageAsync(string recipient, string body)
		{
			if(string.IsNullOrEmpty(recipient))
				throw new ArgumentNullException(nameof(recipient));
			
			if(string.IsNullOrEmpty(body))
				throw new ArgumentNullException(nameof(body));
			
			var endpointUrl = string.Concat(GetEndpointBaseUrl(), sendMessageUrl);
			endpointUrl = string.Format(endpointUrl, recipient);
			
			object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
            	content.Add(new StringContent(body), "body");
            	
            	result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content);
            }
            
            return result;
		}

		public async Task<object> DeleteConversation(string id)
		{
			if(string.IsNullOrEmpty(id))
				throw new ArgumentNullException(nameof(id));
			
			var endpointUrl = string.Concat(GetEndpointBaseUrl(), deleteConversationUrl);
			endpointUrl = string.Format(endpointUrl, id);
			
			var result = MakeEndpointRequestAsync<object>(HttpMethod.Delete, endpointUrl);
			return result;
		}

		public async Task<object> ReportSenderAsync(string username)
		{
			if(string.IsNullOrEmpty(username))
				throw new ArgumentNullException(nameof(username));
			
			var endpointUrl = string.Concat(GetEndpointBaseUrl(), reportSenderUrl);
			endpointUrl = string.Format(endpointUrl, username);
			
			var result = MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl);
			return result;
		}

		public async Task<object> BlockSenderAsync(string username)
		{
			if(string.IsNullOrEmpty(username))
				throw new ArgumentNullException(nameof(username));
			
			var endpointUrl = string.Concat(GetEndpointBaseUrl(), blockSenderUrl);
			endpointUrl = string.Format(endpointUrl, username);
			
			var result = MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl);
			return result;
		}

		#endregion
	}
}
