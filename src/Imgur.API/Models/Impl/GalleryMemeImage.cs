/*
 * Created by SharpDevelop.
 * User: lbokkers
 * Date: 10-12-2015
 * Time: 4:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    /// Description of GalleryMemeImage.
    /// </summary>
    public class GalleryMemeImage : GalleryImage, IGalleryMeme
    {
        /// <summary>
        ///     The name of the meme used.
        /// </summary>
		[JsonProperty("meme_name")]
        public string MemeName { get; set; }

        /// <summary>
        ///     The top text of the meme.
        /// </summary>
        [JsonProperty("top_text")]
        public string TopText { get; set; }

        /// <summary>
        ///     The bottom text of the meme.
        /// </summary>
        [JsonProperty("bottom_text")]
        public string BottomText { get; set; }

        /// <summary>
        ///     The image id of the background image of the meme.
        /// </summary>
        [JsonProperty("bg_image")]
        public string BgImage { get; set; }
    }
}
