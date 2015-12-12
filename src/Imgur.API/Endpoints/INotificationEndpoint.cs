using Imgur.API.Models;
using Imgur.API.Models.Impl;
using System.Threading.Tasks;

namespace Imgur.API.Endpoints
{
    /// <summary>
    /// Notification related actions.
    /// </summary>
    public interface INotificationEndpoint : IEndpoint
    {
        /// <summary>
        /// Get all notifications for the user that's currently logged in
        /// </summary>
        /// <param name="onlyNewNotifications"></param>
        /// <returns></returns>
        Task<Notifications> GetNotificationsAsync(bool onlyNewNotifications = true);

        /// <summary>
        /// Returns the data about a specific notification
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Notification> GetNotificationAsync(string id);

        /// <summary>
        /// Marks a set of notifications as viewed, this way they no longer shows up in the basic notification request.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<object> MarkNotificationsAsReadAsync(params string[] ids);

        /// <summary>
        /// Marks a notification as viewed, this way it no longer shows up in the basic notification request.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<object> MarkNotificationAsReadAsync(string id);
    }
}
