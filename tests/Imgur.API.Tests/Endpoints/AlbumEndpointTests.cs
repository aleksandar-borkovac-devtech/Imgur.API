using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Threading.Tasks;

namespace Imgur.API.Tests.Endpoints
{
    [TestClass]
    public class AlbumEndpointTests
    {
        [TestMethod]
        public void GetAlbumAsync_WithId_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAlbumEndpoint>();
            endpoint.GetAlbumAsync("1234");
            endpoint.Received().GetAlbumAsync("1234");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAlbumAsync_WithNullId_ThrowsArgumentNullException()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AlbumEndpoint(imgurAuth);
            await endpoint.GetAlbumAsync(null);
        }
    }
}