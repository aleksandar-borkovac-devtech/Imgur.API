using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Enums
{
    /// <summary>
    /// The time window to use with various api requests.
    /// </summary>
    public enum GalleryWindow
    {
        /// <summary>
        /// A day.
        /// </summary>
        Day,

        /// <summary>
        /// A week.
        /// </summary>
        Week,

        /// <summary>
        /// A month.
        /// </summary>
        Month,

        /// <summary>
        /// A year.
        /// </summary>
        Year,

        /// <summary>
        /// EVERYTHING.
        /// </summary>
        All
    }
}
