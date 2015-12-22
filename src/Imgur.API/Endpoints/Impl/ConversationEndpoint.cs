using System;
using System.Threading.Tasks;
using Imgur.API.Models;
using System.Net.Http;
using Imgur.API.Authentication;
using Imgur.API.RequestBuilders;
using System.Collections.Generic;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    /// Implementation of conversation related actions.
    /// </summary>
    public class ConversationEndpoint : EndpointBase, IConversationEndpoint
    {
        /// <summary>
        /// Initializes the conversation endpoint.
        /// </summary>
        /// <param name="client"></param>
        public ConversationEndpoint(IApiClient client) : base(client)
        {
        }

        internal ConversationEndpoint(IApiClient client, HttpClient httpClient) : base(client, httpClient)
        {
        }

        internal ConversationRequestBuilder RequestBuilder { get; } = new ConversationRequestBuilder();

        /// <summary>
        /// Get list of all conversations for the logged in user.
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<IConversation>> GetConversationListAsync()
        {
            var url = "conversations";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var conversations = await SendRequestAsync<IConversation[]>(request);
                return conversations;
            }
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
            var url = $"conversations/{id}/{page}/{offset}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var conversation = await SendRequestAsync<IConversation>(request);
                return conversation;
            }
        }

        /// <summary>
        /// Sends a new message.
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<bool> SendMessageAsync(string recipient, string body)
        {
            if (string.IsNullOrEmpty(recipient))
                throw new ArgumentNullException(nameof(recipient));

            if (string.IsNullOrEmpty(body))
                throw new ArgumentNullException(nameof(body));

            var url = $"conversations/{recipient}";

            using (var request = RequestBuilder.PostConversationMessageRequest(url, body))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }

        /// <summary>
        /// Delete a conversation by the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteConversation(int id)
        {
            var url = $"conversation/{id}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Delete, url))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }

        /// <summary>
        /// Report a user for sending messages that are against the Terms of Service.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<bool> ReportSenderAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            var url = $"conversation/report/{username}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Post, url))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }

        /// <summary>
        /// Block the user from sending messages to the user that is logged in.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<bool> BlockSenderAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            var url = $"conversation/block/{username}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Post, url))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }
    }
}
