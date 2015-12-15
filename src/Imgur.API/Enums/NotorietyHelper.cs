using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Enums
{
    /// <summary>
    /// Contains helpers for the <see cref="Notoriety"/> enum.
    /// </summary>
    public class NotorietyHelper
    {
        /// <summary>
        /// Converts a reputation into a <see cref="Notoriety"/>.
        /// </summary>
        /// <param name="reputation">The reputation to convert.</param>
        /// <returns>The notoriety.</returns>
        public static Notoriety FromReputation(float reputation)
        {
            if (reputation < 0)
                return Notoriety.ForeverAlone;

            if (reputation <= 399)
                return Notoriety.Neutral;

            if (reputation <= 999)
                return Notoriety.Accepted;

            if (reputation <= 1999)
                return Notoriety.Liked;

            if (reputation <= 3999)
                return Notoriety.Trusted;

            if (reputation <= 7999)
                return Notoriety.Idolized;

            if (reputation <= 19999)
                return Notoriety.Renowned;

            return Notoriety.Glorious;
        }

        /// <summary>
        /// Converts a <see cref="Notoriety"/> to a string.
        /// </summary>
        /// <param name="notoriety">The notoriety to convert.</param>
        /// <returns>The string representation.</returns>
        public static string NotorietyToString(Notoriety notoriety)
        {
            switch (notoriety)
            {
                case Notoriety.ForeverAlone:
                    return "Forever Alone";

                default:
                    return notoriety.ToString();
            }
        }
    }
}
