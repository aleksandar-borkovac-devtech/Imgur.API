using Imgur.API.Enums;
using System;

namespace Imgur.API.Models
{
    /// <summary>
    ///     This model is used to represent the basic account information.
    /// </summary>
    public interface IAccount : IDataModel
    {
        /// <summary>
        ///     A basic description the user has filled out.
        /// </summary>
        string Bio { get; set; }

        /// <summary>
        ///     Utc timestamp of account creation, converted from epoch time.
        /// </summary>
        DateTimeOffset Created { get; set; }

        /// <summary>
        ///     The account id for the username requested.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        ///     The reputation for the account, in its numerical format.
        /// </summary>
        float Reputation { get; set; }

        /// <summary>
        ///     The users notoriety.
        /// </summary>
        Notoriety Notoriety { get; }

        /// <summary>
        ///     The users url username.
        /// </summary>
        string Url { get; set; }
    }
}