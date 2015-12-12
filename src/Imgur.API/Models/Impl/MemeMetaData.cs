/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 4:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;
using System;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    /// Represents basic meme metadata.
    /// </summary>
    public class MemeMetaData : IMemeMetaData
    {
        /// <summary>
        /// The name of the meme used.
        /// </summary>
        [JsonProperty("meme_name")]
        public string MemeName { get; set; }

        /// <summary>
        /// The top text of the meme.
        /// </summary>
        [JsonProperty("top_text")]
        public string TopText { get; set; }

        /// <summary>
        /// The bottom text of the meme.
        /// </summary>
        [JsonProperty("bottom_text")]
        public string BottomText { get; set; }

        /// <summary>
        /// The image id of the background image of the meme.
        /// </summary>
        [JsonProperty("bg_image")]
        public string BgImage { get; set; }
    }
}

