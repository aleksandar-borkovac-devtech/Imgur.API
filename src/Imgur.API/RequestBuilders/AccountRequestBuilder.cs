﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Imgur.API.Enums;

namespace Imgur.API.RequestBuilders
{
    internal class AccountRequestBuilder : RequestBuilderBase
    {
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        internal HttpRequestMessage UpdateAccountSettingsRequest(
            string url,
            string bio = null,
            bool? publicImages = null,
            bool? messagingEnabled = null,
            AlbumPrivacy? albumPrivacy = null,
            bool? acceptedGalleryTerms = null,
            string username = null,
            bool? showMature = null,
            bool? newsletterSubscribed = null)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var parameters = new Dictionary<string, string>();

            if (publicImages != null)
                parameters.Add("public_images", $"{publicImages}".ToLower());

            if (messagingEnabled != null)
                parameters.Add("messaging_enabled", $"{messagingEnabled}".ToLower());

            if (albumPrivacy != null)
                parameters.Add("album_privacy", $"{albumPrivacy}".ToLower());

            if (acceptedGalleryTerms != null)
                parameters.Add("accepted_gallery_terms", $"{acceptedGalleryTerms}".ToLower());

            if (showMature != null)
                parameters.Add("show_mature", $"{showMature}".ToLower());

            if (newsletterSubscribed != null)
                parameters.Add("newsletter_subscribed", $"{newsletterSubscribed}".ToLower());

            if (!string.IsNullOrWhiteSpace(username))
                parameters.Add(nameof(username), username);

            if (!string.IsNullOrWhiteSpace(bio))
                parameters.Add(nameof(bio), bio);

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(parameters.ToArray())
            };

            return request;
        }
    }
}