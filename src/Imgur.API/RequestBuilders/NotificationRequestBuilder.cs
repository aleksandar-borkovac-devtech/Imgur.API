using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.RequestBuilders
{
    internal class NotificationRequestBuilder : RequestBuilderBase
    {
        internal HttpRequestMessage MarkAsReadRequest(string url, int[] ids)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            var parameters = new Dictionary<string, string>()
            {
                {"ids", string.Format(",", ids)}
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(parameters.ToArray())
            };

            return request;
        }
    }
}
