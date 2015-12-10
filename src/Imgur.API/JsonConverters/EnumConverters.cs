using Imgur.API.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.JsonConverters
{
    public class AlbumLayoutConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;

            switch(enumString)
            {
                case "blog":
                    return AlbumLayout.Blog;

                case "grid":
                    return AlbumLayout.Grid;

                case "horizontal":
                    return AlbumLayout.Horizontal;

                case "vertical":
                    return AlbumLayout.Vertical;

                default:
                    throw new ArgumentException(
                        string.Format("Invalid value {0} for album layout.", enumString)
                        );
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public class AlbumPrivacyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;

            switch (enumString)
            {
                case "public":
                    return AlbumPrivacy.Public;

                case "secret":
                    return AlbumPrivacy.Secret;

                case "hidden":
                    return AlbumPrivacy.Hidden;

                default:
                    throw new ArgumentException(
                        string.Format("Invalid value {0} for album privacy.", enumString)
                        );
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
