using System.Collections.Generic;
using Imgur.API.JsonConverters;
using Newtonsoft.Json;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    ///     The base model for notifications.
    /// </summary>
    public class Notifications : INotifications
    {
        /// <summary>
        ///     An array of message notifications.
        /// </summary>
        [JsonProperty("messages")]
        [JsonConverter(typeof(TypeConverter<ICollection<Notification>>))]
        public ICollection<INotification> Messages { get; set; }

        /// <summary>
        ///     An array of comment notifications.
        /// </summary>
        [JsonProperty("messages")]
        [JsonConverter(typeof(TypeConverter<ICollection<Notification>>))]
        public ICollection<INotification> Replies { get; set; }
    }
}