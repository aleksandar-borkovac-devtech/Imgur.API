﻿using Imgur.API.Enums;
using Imgur.API.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    ///     The account settings, only accessible if you're logged in as the user.
    /// </summary>
    public class AccountSettings : IAccountSettings
    {
        /// <summary>
        ///     The users email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     The users ability to upload higher quality images, there will be less compression.
        /// </summary>
        [JsonProperty("high_quality")]
        public bool HighQuality { get; set; }

        /// <summary>
        ///     Automatically allow all images to be publicly accessible.
        /// </summary>
        [JsonProperty("public_images")]
        public bool PublicImages { get; set; }

        /// <summary>
        ///     Set the album privacy to this privacy setting on creation.
        /// </summary>
        [JsonProperty("album_privacy")]
        public AlbumPrivacy AlbumPrivacy { get; set; }

        /// <summary>
        ///     True if the user has accepted the terms of uploading to the Imgur gallery.
        /// </summary>
        [JsonProperty("accepted_gallery_terms")]
        public bool AcceptedGalleryTerms { get; set; }

        /// <summary>
        ///     The email addresses that have been activated to allow uploading.
        /// </summary>
        [JsonProperty("active_emails")]
        [JsonConverter(typeof(TypeConverter<ICollection<string>>))]
        public ICollection<string> ActiveEmails { get; set; }

        /// <summary>
        ///     If the user is accepting incoming messages or not.
        /// </summary>
        [JsonProperty("messaging_enabled")]
        public bool MessagingEnabled { get; set; }

        /// <summary>
        ///     An array of users that have been blocked from messaging.
        /// </summary>
        [JsonProperty("blocked_users")]
        [JsonConverter(typeof(TypeConverter<ICollection<IBlockedUser>>))]
        public ICollection<IBlockedUser> BlockedUsers { get; set; }

        /// <summary>
        ///     True if the user has opted to have mature images displayed in gallery list endpoints.
        /// </summary>
        [JsonProperty("show_mature")]
        public bool ShowMature { get; set; }
    }
}