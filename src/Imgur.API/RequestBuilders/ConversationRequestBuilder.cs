using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.RequestBuilders
{
    internal class ConversationRequestBuilder : RequestBuilderBase
    {
        internal HttpRequestMessage PostConversationMessageRequest(string url, string body)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            if (string.IsNullOrEmpty(body))
                throw new ArgumentNullException(nameof(body));

            var parameters = new Dictionary<string, string>()
            {
                { "body", body }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(parameters.ToArray())
            };

            return request;
        }
    }
}
