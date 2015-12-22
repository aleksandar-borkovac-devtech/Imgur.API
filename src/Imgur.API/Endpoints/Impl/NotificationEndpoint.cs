using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.API.Models;
using Imgur.API.Models.Impl;
using System.Net.Http;
using Imgur.API.Authentication;
using Imgur.API.RequestBuilders;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    /// Implementation of notification related actions.
    /// </summary>
    public class NotificationEndpoint : EndpointBase, INotificationEndpoint
    {
        /// <summary>
        /// Initializes a new instance of the NotificationEndpoint.
        /// </summary>
        /// <param name="client">The API client to use.</param>
        public NotificationEndpoint(IApiClient client) : base(client)
        {
        }

        internal NotificationEndpoint(IApiClient client, HttpClient httpClient) : base(client, httpClient)
        {
        }

        internal NotificationRequestBuilder RequestBuilder { get; } = new NotificationRequestBuilder();

        /// <summary>
        /// Returns the data about a specific notification.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Notification> GetNotificationAsync(int id)
        {
            var url = $"notification/{id}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var notification = await SendRequestAsync<Notification>(request);
                return notification;
            }
        }

        /// <summary>
        /// Get all notifications for the user that's currently logged in.
        /// </summary>
        /// <param name="onlyNewNotifications"></param>
        /// <returns></returns>
        public async Task<Notifications> GetNotificationsAsync(bool onlyNewNotifications = true)
        {
            var url = $"notifications?new={onlyNewNotifications}";

            using (var request = RequestBuilder.CreateRequest(HttpMethod.Get, url))
            {
                var notifications = await SendRequestAsync<Notifications>(request);
                return notifications;
            }
        }

        /// <summary>
        /// Marks a set of notifications as viewed, this way they no longer shows up in the basic notification request.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<bool> MarkNotificationsAsReadAsync(params int[] ids)
        {
            if (ids.Length == 0)
                throw new ArgumentException("Need at least one notification to mark as read.");

            var url = "notification";

            using (var request = RequestBuilder.MarkAsReadRequest(url, ids))
            {
                var result = await SendRequestAsync<bool>(request);
                return result;
            }
        }
    }
}
