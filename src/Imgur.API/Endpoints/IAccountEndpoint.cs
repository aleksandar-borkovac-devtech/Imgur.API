using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imgur.API.Enums;
using Imgur.API.Models;
using Imgur.API.Exceptions;

namespace Imgur.API.Endpoints
{
    /// <summary>
    ///     Account related actions.
    /// </summary>
    public interface IAccountEndpoint : IEndpoint
    {
        /// <summary>
        ///     Delete an Album with a given id. OAuth authentication required.
        /// </summary>
        /// <param name="id">The album id.</param>
        /// <param name="username">The user account. Default: me</param>
        /// <returns></returns>
        Task<bool> DeleteAlbumAsync(string id, string username = "me");

        /// <summary>
        ///     Delete a comment. OAuth authentication required.
        /// </summary>
        /// <param name="id">The comment id.</param>
        /// <param name="username">The user account. Default: me</param>
        /// <returns></returns>
        Task<bool> DeleteCommentAsync(string id, string username = "me");

        /// <summary>
        ///     Deletes an Image. OAuth authentication required.
        /// </summary>
        /// <param name="id">The image id.</param>
        /// <param name="username">The user account. Default: me</param>
        /// <returns></returns>
        Task<bool> DeleteImageAsync(string id, string username = "me");

        /// <summary>
        ///     Request standard user information.
        ///     If you need the username for the account that is logged in, it is returned in the request for an access token.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <returns></returns>
        Task<IAccount> GetAccountAsync(string username = "me");

        /// <summary>
        ///     Returns the users favorited images, only accessible if you're logged in as the user.
        /// </summary>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of gallery submissions.</returns>
        Task<ICollection<IGalleryAlbumImageBase>> GetAccountFavoritesAsync();

        /// <summary>
        ///     Return the images the user has favorited in the gallery.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="page">Set the page number so you don't have to retrieve all the data at once. Default: null.</param>
        /// <param name="sort">Indicates the order that a list of items are sorted. Default: Newest.</param>
        /// <returns></returns>
        Task<ICollection<IGalleryAlbumImageBase>> GetAccountGalleryFavoritesAsync(string username = "me", int? page = null,
            GallerySortOrder? sort = GallerySortOrder.Newest);


        /// <summary>
        ///     Returns the account settings, only accessible if you're logged in as the user.
        /// </summary>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of gallery submissions.</returns>
        Task<IAccountSettings> GetAccountSettingsAsync();

        /// <summary>
        ///     Return the images a user has submitted to the gallery.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="page">Set the page number so you don't have to retrieve all the data at once. Default: null.</param>
        /// <returns></returns>
        Task<ICollection<IGalleryAlbumImageBase>> GetAccountSubmissionsAsync(string username = "me", int? page = null);

        /// <summary>
        ///     Get additional information about an album, this works the same as the Album Endpoint.
        /// </summary>
        /// <param name="id">The album's id.</param>
        /// <param name="username">The user account. Default: me</param>
        /// <returns></returns>
        Task<IAlbum> GetAlbumAsync(string id, string username = "me");

        /// <summary>
        ///     Return the total number of albums associated with the account.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <returns></returns>
        Task<int> GetAlbumCountAsync(string username = "me");

        /// <summary>
        ///     Return an array of all of the album IDs.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
        /// <returns></returns>
        Task<ICollection<string>> GetAlbumIdsAsync(string username = "me", int? page = null);

        /// <summary>
        ///     Get all the albums associated with the account.
        ///     Must be logged in as the user to see secret and hidden albums.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of albums.</returns>
        Task<ICollection<IAlbum>> GetAlbumsAsync(string username = "me", int? page = null);

        /// <summary>
        ///     Return information about a specific comment.
        /// </summary>
        /// <param name="id">The comment id.</param>
        /// <param name="username">The user account. Default: me</param>
        /// <returns></returns>
        Task<IComment> GetCommentAsync(string id, string username = "me");

        /// <summary>
        ///     Return a count of all of the comments associated with the account.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <returns></returns>
        Task<int> GetCommentCountAsync(string username = "me");

        /// <summary>
        ///     Return an array of all of the comment IDs.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="sort">'best', 'worst', 'oldest', or 'newest'. Defaults to 'newest'.</param>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
        /// <returns></returns>
        Task<ICollection<string>> GetCommentIdsAsync(string username = "me",
            CommentSortOrder? sort = CommentSortOrder.Newest, int? page = null);

        /// <summary>
        ///     Fetch the comments the user has created.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="sort">'best', 'worst', 'oldest', or 'newest'. Defaults to 'newest'.</param>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
        /// <returns></returns>
        Task<ICollection<IComment>> GetCommentsAsync(string username = "me",
            CommentSortOrder? sort = CommentSortOrder.Newest, int? page = null);

        /// <summary>
        ///     The totals for a users gallery information.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <returns></returns>
        Task<IGalleryProfile> GetGalleryProfileAsync(string username = "me");

        /// <summary>
        ///     Return information about a specific image.
        /// </summary>
        /// <param name="id">The images's id.</param>
        /// <param name="username">The user account. Default: me</param>
        /// <returns></returns>
        Task<IImage> GetImageAsync(string id, string username = "me");

        /// <summary>
        ///     Returns the total number of images associated with the account.
        ///     OAuth authentication required.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <returns></returns>
        Task<int> GetImageCountAsync(string username = "me");

        /// <summary>
        ///     Returns an array of Image IDs that are associated with the account. OAuth authentication required.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
        /// <returns></returns>
        Task<ICollection<string>> GetImageIdsAsync(string username = "me", int? page = null);

        /// <summary>
        ///     Fetch all of the images associated with the account.
        ///     You can page through the images by setting the page, this defaults to 0.
        ///     OAuth authentication required.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
        /// <returns></returns>
        Task<ICollection<IImage>> GetImagesAsync(string username = "me", int? page = null);

        /// <summary>
        ///     Returns all of the notifications for the user.
        ///     OAuth authentication required.
        /// </summary>
        /// <param name="newNotifications">false for all notifications, true for only non-viewed notification. Default is true.</param>
        /// <returns></returns>
        Task<INotifications> GetNotificationsAsync(bool newNotifications = true);

        /// <summary>
        ///     Sends an email to the user to verify that their email is valid to upload to gallery.
        ///     OAuth authentication required.
        /// </summary>
        /// <returns></returns>
        Task<bool> SendVerificationEmailAsync();

        /// <summary>
        ///     Updates the account settings for a given user, the user must be logged in.
        ///     OAuth authentication required.
        /// </summary>
        /// <param name="bio">The biography of the user, is displayed in the gallery profile page.</param>
        /// <param name="publicImages">Set the users images to private or public by default.</param>
        /// <param name="messagingEnabled">Allows the user to enable / disable private messages.</param>
        /// <param name="albumPrivacy">Sets the default privacy level of albums the users creates.</param>
        /// <param name="acceptedGalleryTerms">The user agreement to the Imgur Gallery terms.</param>
        /// <param name="username">A valid Imgur username (between 4 and 63 alphanumeric characters).</param>
        /// <param name="showMature">Toggle display of mature images in gallery list endpoints.</param>
        /// <param name="newsletterSubscribed">Toggle subscription to email newsletter.</param>
        /// <returns></returns>
        Task<bool> UpdateAccountSettingsAsync(
            string bio = null,
            bool? publicImages = null,
            bool? messagingEnabled = null,
            AlbumPrivacy? albumPrivacy = null,
            bool? acceptedGalleryTerms = null,
            string username = null,
            bool? showMature = null,
            bool? newsletterSubscribed = null);

        /// <summary>
        ///     Checks to see if user has verified their email address.
        ///     OAuth authentication required.
        /// </summary>
        /// <returns></returns>
        Task<bool> VerifyEmailAsync();
    }
}
