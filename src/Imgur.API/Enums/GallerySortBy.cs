using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Enums
{
    /// <summary>
    /// By what metric the gallery should be sorted.
    /// </summary>
    public enum GallerySortBy
    {
        /// <summary>
        /// Viral posts.
        /// </summary>
        Viral,

        /// <summary>
        /// Top posts.
        /// </summary>
        Top,

        /// <summary>
        /// Post upload time.
        /// </summary>
        Time,

        /// <summary>
        /// Rising posts (only available with user section).
        /// </summary>
        Rising
    }
}
