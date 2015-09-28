﻿using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointTests
{
    [TestClass]
    public class AccountEndpointMashapeAuthTests : TestBase
    {
        [TestMethod]
        public async Task GetAccountAsync_WithUsername_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var account = await endpoint.GetAccountAsync("sarah");

            Assert.AreEqual("sarah", account.Url.ToLower());
        }

        [TestMethod]
        public async Task GetAccountGalleryFavoritesAsync_Any_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var favourites = await endpoint.GetAccountGalleryFavoritesAsync("sarah");

            Assert.IsTrue(favourites.Any());
        }

        [TestMethod]
        public async Task GetAccountSubmissionsAsync_Any_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var submissions = await endpoint.GetAccountSubmissionsAsync("sarah");

            Assert.IsTrue(submissions.Any());
        }
    }
}