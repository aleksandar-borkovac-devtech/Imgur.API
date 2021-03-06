﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Imgur.API.Authentication;
using Imgur.API.Exceptions;
using Imgur.API.Models;
using Imgur.API.Models.Impl;
using Imgur.API.RequestBuilders;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    ///     Gets credit limit.
    /// </summary>
    public class RateLimitEndpoint : EndpointBase, IRateLimitEndpoint
    {
        /// <summary>
        ///     Initializes a new instance of the RateLimitEndpoint class.
        /// </summary>
        /// <param name="apiClient">The type of client that will be used for authentication.</param>
        public RateLimitEndpoint(IApiClient apiClient) : base(apiClient)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the RateLimitEndpoint class.
        /// </summary>
        /// <param name="apiClient">The type of client that will be used for authentication.</param>
        /// <param name="httpClient"> The class for sending HTTP requests and receiving HTTP responses from the endpoint methods.</param>
        internal RateLimitEndpoint(IApiClient apiClient, HttpClient httpClient) : base(apiClient, httpClient)
        {
        }

        internal RateLimitRequestBuilder RequestBuilder { get; } = new RateLimitRequestBuilder();

        /// <summary>
        ///     Get RateLimit.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MashapeException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <returns></returns>
        public async Task<IRateLimit> GetRateLimitAsync()
        {
            IRateLimit limit;

            var url = "credits";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                limit = await SendRequestAsync<RateLimit>(request);
            }

            return limit;
        }
    }
}