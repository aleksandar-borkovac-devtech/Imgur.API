using Imgur.API.Models;
using Imgur.API.Exceptions;
using System.Threading.Tasks;

namespace Imgur.API.Endpoints
{
    /// <summary>
    /// Meme generation related endpoints.
    /// 
    /// It's currently not yet possible to create memes via the API. If you're interested in this feature then let the Imgur team know by posting on the Imgur API Google Group.
    /// https://groups.google.com/forum/?fromgroups#!forum/imgur
    /// </summary>
    public interface IMemeGenEndpoint : IEndpoint
    {
        /// <summary>
        /// 	Get the list of default memes.
        /// </summary>
        /// <exception cref="ImgurException">Thrown when Imgur encounters an error.</exception>
        /// <returns>An array containing the default images.</returns>
        Task<IImage[]> GetDefaultMemesAsync();
    }
}
