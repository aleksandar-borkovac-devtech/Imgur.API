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
        
        [TestMethod]
        public void GetAlbumImageAsync_WithIds_ReceivedIsTrue()
        {
        	var endpoint = Substitute.For<IAlbumEndpoint>();
        	endpoint.GetAlbumImageAsync("1234", "12345");
        	endpoint.Received().GetAlbumImageAsync("1234", "12345");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAlbumImageAsync_WithNullId_ThrowsArgumentNullException()
        {
        	var imgurAuth = new ImgurClient("123", "1234");
        	var endpoint = new AlbumEndpoint(imgurAuth);
        	await endpoint.GetAlbumImageAsync(null, "567");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAlbumImageAsync_WithNullImageId_ThrowsArgumentNullException()
        {
        	var imgurAuth = new ImgurClient("123", "1234");
        	var endpoint = new AlbumEndpoint(imgurAuth);
        	await endpoint.GetAlbumImageAsync("890", null);
        }
        
        [TestMethod]
        public void GetAlbumImagesAsync_WithId_ReceivedIsTrue()
        {
        	var endpoint = Substitute.For<IAlbumEndpoint>();
        	endpoint.GetAlbumImagesAsync("1234");
        	endpoint.Received().GetAlbumImagesAsync("1234");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAlbumImagesAsync_WithId_ThrowsArgumentNullException()
        {
        	var imgurAuth = new ImgurClient("123", "1234");
        	var endpoint = new AlbumEndpoint(imgurAuth);
        	await endpoint.GetAlbumImagesAsync("456");
        }
        
        [TestMethod]
        public void CreateAlbumAsync_WithDefaultArgs_ReceivedIsTrue()
        {
        	var endpoint = Substitute.For<IAlbumEndpoint>();
        	endpoint.CreateAlbumAsync();
        	endpoint.Received().CreateAlbumAsync();
        }
        
        [TestMethod]
        public void AddAlbumImagesAsync_WithIdAndImages_ReceivedIsTrue()
        {
        	var endpoint = Substitute.For<IAlbumEndpoint>();
        	endpoint.AddAlbumImagesAsync("1234", new string[] {"567", "890"});
        	endpoint.Received().AddAlbumImagesAsync("1234", new string[]{"567", "890"});
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task AddAlbumImagesAsync_WithId_ThrowsArgumentNullException()
        {
        	var imgurAuth = new ImgurClient("123", "1234");
        	var endpoint = new AlbumEndpoint(imgurAuth);
        	await endpoint.AddAlbumImagesAsync(null, new string[]{"123"});
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task AddAlbumImagesAsync_WithImages_ThrowsArgumentNullException()
        {
        	var imgurAuth = new ImgurClient("123", "1234");
        	var endpoint = new AlbumEndpoint(imgurAuth);
        	await endpoint.AddAlbumImagesAsync("123", null);
        }
        
        [TestMethod]
        public void DeleteAlbumAsync_WithId_ReceivedIsTrue()
        {
        	var endpoint = Substitute.For<IAlbumEndpoint>();
        	endpoint.DeleteAlbumAsync("1234");
        	endpoint.Received().DeleteAlbumAsync("1234");
        }
    }
}