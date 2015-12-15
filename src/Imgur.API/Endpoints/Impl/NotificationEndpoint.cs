using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.API.Models;
using Imgur.API.Models.Impl;
using System.Net.Http;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    /// Implementation of notification related actions.
    /// </summary>
    public class NotificationEndpoint : EndpointBase, INotificationEndpoint
    {
        private const string getNotificationsUrl = "notification?new={0}";
        private const string getNotificationUrl = "notification/{0}";
        private const string markNotificationAsReadUrl = "notification";
        private const string markNotificationsAsReadUrl = "notification/{0}";

        /// <summary>
        /// Returns the data about a specific notification
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Notification> GetNotificationAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getNotificationUrl);
            endpointUrl = string.Format(endpointUrl, id);

            var notification = await MakeEndpointRequestAsync<Notification>(HttpMethod.Get, endpointUrl, requiresAuth: true);
            return notification;
        }

        /// <summary>
        /// Get all notifications for the user that's currently logged in
        /// </summary>
        /// <param name="onlyNewNotifications"></param>
        /// <returns></returns>
        public async Task<Notifications> GetNotificationsAsync(bool onlyNewNotifications = true)
        {
            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getNotificationUrl);
            endpointUrl = string.Format(endpointUrl, onlyNewNotifications);

            var notifications = await MakeEndpointRequestAsync<Notifications>(HttpMethod.Get, endpointUrl, requiresAuth: true);
            return notifications;
        }

        /// <summary>
        /// Marks a notification as viewed, this way it no longer shows up in the basic notification request.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<object> MarkNotificationAsReadAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), markNotificationAsReadUrl);
            endpointUrl = string.Format(endpointUrl, id);

            var result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, requiresAuth: true);
            return result;
        }

        /// <summary>
        /// Marks a set of notifications as viewed, this way they no longer shows up in the basic notification request.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<object> MarkNotificationsAsReadAsync(params string[] ids)
        {
            if (ids.Length == 0)
                return MarkNotificationAsReadAsync(ids[0]);

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), markNotificationsAsReadUrl);

            object result;
            using (var content = new MultipartFormDataContent(DateTime.UtcNow.Ticks.ToString()))
            {
                content.Add(new StringContent(string.Join(",", ids)), "ids");

                result = await MakeEndpointRequestAsync<object>(HttpMethod.Post, endpointUrl, requiresAuth: true);
            }

            return result;
        }
    }
}
