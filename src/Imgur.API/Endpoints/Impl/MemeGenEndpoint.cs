using System;
using System.Threading.Tasks;
using Imgur.API.Models;
using System.Net.Http;
using Imgur.API.Exceptions;
using Imgur.API.Authentication;
using Imgur.API.RequestBuilders;
using Imgur.API.Models.Impl;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    /// Implementation of meme generation related endpoints.
    /// 
    /// It's currently not yet possible to create memes via the API. If you're interested in this feature then let the Imgur team know by posting on the Imgur API Google Group.
    /// https://groups.google.com/forum/?fromgroups#!forum/imgur
    /// </summary>
    public class MemeGenEndpoint : EndpointBase, IMemeGenEndpoint
    {
        /// <summary>
        /// Initializes a new instance of the MemegenEndpoint.
        /// </summary>
        /// <param name="client">The API client to use.</param>
        public MemeGenEndpoint(IApiClient client) : base(client)
        {
        }

        internal MemeGenEndpoint(IApiClient client, HttpClient httpClient) : base(client, httpClient)
        {
        }

        internal MemeGenRequestBuilder RequestBuilder { get; } = new MemeGenRequestBuilder();

        /// <summary>
        /// 	Get the list of default memes.
        /// </summary>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns>An array containing the default images.</returns>
        public async Task<IImage[]> GetDefaultMemesAsync()
        {
            var url = "memegen/defaults";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var images = await SendRequestAsync<Image[]>(request);
                return images;
            }
        }
    }
}
