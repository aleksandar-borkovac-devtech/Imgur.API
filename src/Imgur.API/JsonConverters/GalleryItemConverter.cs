﻿using System;
using System.Reflection;
using Imgur.API.Models;
using Imgur.API.Models.Impl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Imgur.API.JsonConverters
{
    /// <summary>
    ///     Converts Gallery items to their appropriate type.
    /// </summary>
    public class GalleryItemConverter : JsonConverter
    {
        /// <summary>
        ///     Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            if (typeof (IGalleryAlbumImageBase).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                return true;

            return false;
        }

        /// <summary>
        ///     Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The Newtonsoft.Json.JsonReader to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jsonString = JObject.Load(reader).ToString();

            if (jsonString.Replace(" ", "").Contains("is_album\":true"))
            {
                var album = JsonConvert.DeserializeObject<GalleryAlbum>(jsonString);
                return album;
            }

            var image = JsonConvert.DeserializeObject<GalleryImage>(jsonString);
            return image;
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}