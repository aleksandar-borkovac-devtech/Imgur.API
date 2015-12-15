using System;
using System.Threading.Tasks;
using Imgur.API.Models;
using System.Net.Http;
using Imgur.API.Exceptions;

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
        private const string getDefaultMemesUrl = "memegen/defaults";

        /// <summary>
        /// 	Get the list of default memes.
        /// </summary>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns>An array containing the default images.</returns>
        public async Task<IImage[]> GetDefaultMemesAsync()
        {
            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getDefaultMemesUrl);

            var result = await MakeEndpointRequestAsync<IImage[]>(HttpMethod.Get, endpointUrl);
            return result;
        }
    }
}