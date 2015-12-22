using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.RequestBuilders
{
    internal class CustomGalleryRequestBuilder : RequestBuilderBase
    {
        internal HttpRequestMessage AddCustomGalleryTagsRequest(string url, string[] tags)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            var parameters = new Dictionary<string, string>()
            {
                { "tags", string.Join(",", tags) }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(parameters.ToArray())
            };

            return request;
        }

        internal HttpRequestMessage AddBlockedOutGalleryRequest(string url, string tag)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            if (string.IsNullOrEmpty(tag))
                throw new ArgumentNullException(nameof(tag));

            var parameters = new Dictionary<string, string>()
            {
                { "tag", tag }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(parameters.ToArray())
            };

            return request;
        }

        internal HttpRequestMessage RemoveBlockedOutGalleryRequest(string url, string tag)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            if (string.IsNullOrEmpty(tag))
                throw new ArgumentNullException(nameof(tag));

            var parameters = new Dictionary<string, string>()
            {
                { "tag", tag }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(parameters.ToArray())
            };

            return request;
        }

        internal HttpRequestMessage RemoveCustomGalleryRequest(string url, string[] tags)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            var parameters = new Dictionary<string, string>()
            {
                { "tags", string.Join(",", tags) }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(parameters.ToArray())
            };

            return request;
        }
    }
}
