namespace Imgur.API.Enums
{
    /// <summary>
    ///     The various thumbnail sizes.
    /// </summary>
    public enum ThumbnailSize
    {
        /// <summary>
        /// Small square thumbnail, 90x90 px, Keeps Image Propertions = no
        /// </summary>
        SmallSquare,

        /// <summary>
        /// Big square thumbnail, 160x160 px, Keeps Image Propertions = no
        /// </summary>
        BigSquare,


        /// <summary>
        /// Small thumbnail, 160x160 px, Keeps Image Propertions = yes
        /// </summary>
        Small,

        /// <summary>
        /// Medium thumbnail,320x320 px, Keeps Image Propertions = yes
        /// </summary>
        Medium,

        /// <summary>
        /// Large thumbnail, 640x640 px, Keeps Image Propertions = yes
        /// </summary>
        Large,

        /// <summary>
        /// Huge thumbnail, 1024x1024 px, Keeps Image Propertions = yes
        /// </summary>
        Huge
    }
}