using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Enums
{
    /// <summary>
    /// Notoriety levels for a user.
    /// </summary>
    public enum Notoriety
    {
        /// <summary>
        /// Reputation of less than 0.
        /// </summary>
        ForeverAlone,

        /// <summary>
        /// Reputation of 0 to 399
        /// </summary>
        Neutral,

        /// <summary>
        /// Reputation of 400 to 999.
        /// </summary>
        Accepted,

        /// <summary>
        /// Reputation of 1000 to 1999.
        /// </summary>
        Liked,

        /// <summary>
        /// Reputation of 2000 to 3999.
        /// </summary>
        Trusted,

        /// <summary>
        /// Reputation of 4000 to 7999.
        /// </summary>
        Idolized,

        /// <summary>
        /// Reputation of 8000 to 19999.
        /// </summary>
        Renowned,

        /// <summary>
        /// Reputation of higher 20000 or higher.
        /// </summary>
        Glorious
    }
}
