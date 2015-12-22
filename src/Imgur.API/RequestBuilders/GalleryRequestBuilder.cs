using System;
using Imgur.API.Enums;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;

namespace Imgur.API.RequestBuilders
{
    internal class GalleryRequestBuilder : RequestBuilderBase
    {
        internal HttpRequestMessage PostReportRequest(string url, Reporting reason)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var parameters = new Dictionary<string, string>()
            {
                { "reason", ((int)reason).ToString() }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(parameters.ToArray())
            };

            return request;
        }

        internal HttpRequestMessage CommentRequest(string url, string comment)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var parameters = new Dictionary<string, string>()
            {
                { "comment", comment }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(parameters.ToArray())
            };

            return request;
        }

        internal HttpRequestMessage PublishRequest(string url, string title, string topic, bool? acceptTerms, bool? nsfw)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            var parameters = new Dictionary<string, string>()
            {
                { "title", title }
            };

            if (!string.IsNullOrEmpty(topic))
                parameters.Add("topic", topic);

            if (acceptTerms != null)
                parameters.Add("terms", (bool)acceptTerms ? "1" : "0");

            if (nsfw != null)
                parameters.Add("mature", (bool)nsfw ? "1" : "0");

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(parameters.ToArray())
            };

            return request;
        }
    }
}