﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.API.Models;
using Imgur.API.Authentication;
using System.Net.Http;
using Imgur.API.Exceptions;

namespace Imgur.API.Endpoints.Impl
{
    /// <summary>
    ///     Gallery related actions.
    /// </summary>
    public class GalleryEndpoint : EndpointBase, IGalleryEndpoint
    {
        private const string getGalleryUrl = "gallery/{0}/{1}/{2}.json?showViral={3}";
        private const string getGalleryUrl2 = "gallery/{0}/{1}/{2}/{3}.json?showViral={4}";
        private const string getImageUrl = "gallery/image/{0}";

        /// <summary>
        ///     Initializes the endpoint.
        /// </summary>
        /// <param name="apiClient">The client to use.</param>
        public GalleryEndpoint(IApiClient apiClient) : base(apiClient)
        {
        }

        /// <summary>
        ///     Returns the images currently in the gallery.
        /// </summary>
        /// <param name="section">What section of the gallery to fetch.</param>
        /// <param name="sort">How to sort the gallery.</param>
        /// <param name="page">What page of the gallery to fetch.</param>
        /// <param name="showViral">Whether to show viral images or not.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        public async Task<IGalleryItem[]> GetGalleryAsync(GallerySection section = GallerySection.Hot, GallerySortBy sort = GallerySortBy.Viral, uint page = 0, bool showViral = true)
        {
            if(sort == GallerySortBy.Rising && section != GallerySection.User)
                throw new ArgumentException(nameof(sort) + " can only be rising if " + nameof(section) + " is user.");

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getGalleryUrl);
            endpointUrl = string.Format(
                endpointUrl,
                section.ToString().ToLower(),
                sort.ToString().ToLower(),
                page,
                showViral);
            var gallery = await MakeEndpointRequestAsync<IGalleryItem[]>(HttpMethod.Get, endpointUrl);
            return gallery;
        }

        /// <summary>
        ///     Returns the images currently in the gallery.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="sort"></param>
        /// <param name="window"></param>
        /// <param name="page"></param>
        /// <param name="showViral"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        public async Task<IGalleryItem[]> GetGalleryAsync(GallerySection section = GallerySection.Hot, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Day, uint page = 0, bool showViral = true)
        {
            if (sort == GallerySortBy.Rising && section != GallerySection.User)
                throw new ArgumentException(nameof(sort) + " can only be rising if " + nameof(section) + " is user.");

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getGalleryUrl);
            endpointUrl = string.Format(
                endpointUrl,
                section.ToString().ToLower(),
                sort.ToString().ToLower(),
                window.ToString().ToLower(),
                page,
                showViral);
            var gallery = await MakeEndpointRequestAsync<IGalleryItem[]>(HttpMethod.Get, endpointUrl);
            return gallery;
        }

        /// <summary>
        ///     Returns the image identified by the given id.
        /// </summary>
        /// <param name="id">The id of the image to fetch.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        public async Task<IGalleryImage> GetGalleryImageAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(id);

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getImageUrl);
            endpointUrl = string.Format(endpointUrl, id);
            var image = await MakeEndpointRequestAsync<IGalleryImage>(HttpMethod.Get, endpointUrl);
            return image;
        }

        /// <summary>
        ///     Returns the album identified by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ImgurException"></exception>
        /// <returns></returns>
        public async Task<IGalleryAlbum> GetGalleryAlbumAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(id);

            var endpointUrl = string.Concat(GetEndpointBaseUrl(), getImageUrl);
            endpointUrl = string.Format(endpointUrl, id);
            var image = await MakeEndpointRequestAsync<IGalleryAlbum>(HttpMethod.Get, endpointUrl);
            return image;
        }



        public async Task<ITagVote[]> GetGalleryItemTagsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IGalleryItem[]> GetRandomItemsAsync(uint page = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<ITag> GetTagAsync(string tagname, GallerySortBy sort = GallerySortBy.Viral, uint page = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<ITag> GetTagAsync(string tagname, GallerySortBy sort = GallerySortBy.Viral, GalleryWindow window = GalleryWindow.Week, uint page = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<IGalleryImage> GetTagImageAsync(string tagname, string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IBasic<object>> PostGalleryTagVoteAsync(string id, string tagname, Vote vote)
        {
            throw new NotImplementedException();
        }

        public async Task<IBasic<object>> PublishToGalleryAsync(string title, string topic = null, bool acceptTerms = false, bool NSFW = false)
        {
            throw new NotImplementedException();
        }

        public async Task<IBasic<object>> DeleteFromGalleryAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}