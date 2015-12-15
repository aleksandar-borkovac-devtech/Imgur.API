using Imgur.API.Enums;
using Imgur.API.Models;
using System.Threading.Tasks;

namespace Imgur.API.Endpoints
{
    /// <summary>
    ///     Topic related actions.
    /// </summary>
    public interface ITopicEndpoint : IEndpoint
    {
        /// <summary>
        ///     Get the list of default topics.
        /// </summary>
        /// <returns>An array of topics.</returns>
        Task<ITopic[]> GetDefaultTopicsAsync();

        /// <summary>
        ///     View gallery items for a topic.
        /// </summary>
        /// <param name="topicId">The id of the topic.</param>
        /// <param name="sort">How to sort the items in a topic.</param>
        /// <param name="window">How old the items can be.</param>
        /// <param name="page">What page of the topic to fetch.</param>
        /// <returns>An array of gallery items.</returns>
        Task<IGalleryAlbumImageBase[]> GetTopicGalleryItemsAsync(int topicId, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0);

        /// <summary>
        ///     View a single item in a gallery topic.
        /// </summary>
        /// <param name="topicId">The id of the topic.</param>
        /// <param name="itemId">The id of the gallery item.</param>
        /// <returns>A gallery item.</returns>
        Task<IGalleryAlbumImageBase> GetTopicGalleryItemAsync(int topicId, string itemId);
    }
}
