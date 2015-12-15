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
using Imgur.API.Authentication;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    /// Implementation of conversation related actions.
    /// </summary>
    public class ConversationEndpoint : EndpointBase, IConversationEndpoint
    {
        private const string blockSenderUrl = "conversation/block/{0}";
        private const string reportSenderUrl = "conversation/report/{0}";
        private const string sendMessageUrl = "conversation/{0}";
        private const string deleteConversationUrl = "conversation/{0}";
        private const string getConversationUrl = "conversations/{0}/{1}/{2}";
        private const string getConversationsListUrl = "conversations";

        /// <summary>
        /// Initializes the conversation endpoint.
        /// </summary>
        /// <param name="client"></param>
        public ConversationEndpoint(IApiClient client) : base(client)
        {
        }

        /// <summary>
        /// Get list of all conversations for the logged in user.
        /// </summary>
        /// <returns></returns>
        public async Task<IConversation[]> GetConversationListAsync()
        {
            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getConversationsListUrl);

            var result = await MakeEndpointRequestAsync<IConversation[]>(HttpMethod.Get, endpointUrl, requiresAuth: true);
            return result;
        }

        /// <summary>
        /// Get information about a specific conversation. Includes messages.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<IConversation> GetConversationAsync(int id, uint page = 1u, uint offset = 0u)
        {
            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getConversationUrl);
            endpointUrl = string.Format(endpointUrl, id, page, offset);

            var result = await MakeEndpointRequestAsync<IConversation>(HttpMethod.Get, endpointUrl, requiresAuth: true);
            return result;
        }

        /// <summary>
        /// Sends a new message.
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<object> SendMessageAsync(string recipient, string body)
        {
            if (string.IsNullOrEmpty(recipient))
                throw new ArgumentNullException(nameof(recipient));

            if (string.IsNullOrEmpty(body))
                throw new ArgumentNullException(nameof(body));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), sendMessageUrl);
            endpointUrl = string.Format(endpointUrl, recipient);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(body), "body");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, content, requiresAuth: true);
            }

            return result;
        }

        /// <summary>
        /// Delete a conversation by the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<object> DeleteConversation(int id)
        {
            var endpointUrl = string.Concat(GetEndpointBaseUrl(), deleteConversationUrl);
            endpointUrl = string.Format(endpointUrl, id);

            var result = await MakeEndpointRequestAsync<object>(HttpMethod.Delete, endpointUrl, requiresAuth: true);
            return result;
        }

        /// <summary>
        /// Report a user for sending messages that are against the Terms of Service.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<object> ReportSenderAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), reportSenderUrl);
            endpointUrl = string.Format(endpointUrl, username);

            var result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, requiresAuth: true);
            return result;
        }

        /// <summary>
        /// Block the user from sending messages to the user that is logged in.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<object> BlockSenderAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), blockSenderUrl);
            endpointUrl = string.Format(endpointUrl, username);

            var result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, requiresAuth: true);
            return result;
        }
    }
}
