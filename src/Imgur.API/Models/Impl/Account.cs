﻿using System;
using Imgur.API.JsonConverters;
using Newtonsoft.Json;
using Imgur.API.Enums;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    ///     This model is used to represent the basic account information.
    /// </summary>
    public class Account : IAccount
    {
        /// <summary>
        ///     The account id for the username requested.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        ///     The account username, will be the same as requested in the URL.
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        ///     A basic description the user has filled out.
        /// </summary>
        public virtual string Bio { get; set; }

        /// <summary>
        ///     The reputation for the account, in its numerical format.
        /// </summary>
        public virtual float Reputation { get; set; }

        /// <summary>
        ///     Utc timestamp of account creation, converted from epoch time.
        /// </summary>
        [JsonConverter(typeof (EpochTimeConverter))]
        public virtual DateTimeOffset Created { get; set; }

        /// <summary>
        ///     The users notoriety.
        /// </summary>
        public Notoriety Notoriety => NotorietyHelper.FromReputation(Reputation);
    }
}