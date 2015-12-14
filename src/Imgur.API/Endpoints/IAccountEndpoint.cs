using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imgur.API.Enums;
using Imgur.API.Models;

namespace Imgur.API.Endpoints
{
    /// <summary>
    ///     Account related actions.
    /// </summary>
    public interface IAccountEndpoint : IEndpoint
    {
        /// <summary>
        ///     Request standard user information.
        ///     If you need the username for the account that is logged in, it is returned in the request for an access token.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>Account information.</returns>
        Task<IAccount> GetAccountAsync(string username = "me");

        /// <summary>
        ///     Return the images the user has favorited in the gallery.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="page">Set the page number so you don't have to retrieve all the data at once. Default: null.</param>
        /// <param name="gallerySortOrder">Indicates the order that a list of items are sorted. Default: Newest.</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of gallery submissions.</returns>
        Task<IGalleryAlbumImageBase[]> GetAccountGalleryFavoritesAsync(string username = "me", int? page = null,
            GalleryFavoritesSortOrder? gallerySortOrder = GalleryFavoritesSortOrder.Newest);

        /// <summary>
        ///     Returns the users favorited images, only accessible if you're logged in as the user.
        /// </summary>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of gallery submissions.</returns>
        Task<IGalleryAlbumImageBase[]> GetAccountFavoritesAsync();

        /// <summary>
        ///     Return the images a user has submitted to the gallery.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="page">Set the page number so you don't have to retrieve all the data at once. Default: null.</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of gallery submissions.</returns>
        Task<IGalleryAlbumImageBase[]> GetAccountSubmissionsAsync(string username = "me", int? page = null);

        /// <summary>
        ///     Returns the account settings, only accessible if you're logged in as the user.
        /// </summary>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of gallery submissions.</returns>
        Task<IAccountSettings> GetAccountSettingsAsync();

        /// <summary>
        ///     Updates the account settings for a given user, the user must be logged in.
        /// </summary>
        /// <param name="bio">The biography of the user, is displayed in the gallery profile page.</param>
        /// <param name="publicImages">Set the users images to private or public by default.</param>
        /// <param name="messagingEnabled">Allows the user to enable / disable private messages.</param>
        /// <param name="albumPrivacy">Sets the default privacy level of albums the users creates.</param>
        /// <param name="acceptedGalleryTerms"> The user agreement to the Imgur Gallery terms.</param>
        /// <param name="username">A valid Imgur username (between 4 and 63 alphanumeric characters).</param>
        /// <param name="showMature">Toggle display of mature images in gallery list endpoints.</param>
        /// <param name="newsletterSubscribed">Toggle subscription to email newsletter.</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>Whether or not the update succeeded.</returns>
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
        ///     The totals for a users gallery information.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>Gallery Profile information.</returns>
        Task<IGalleryProfile> GetGalleryProfileAsync(string username = "me");

        /// <summary>
        ///     Checks to see if user has verified their email address.
        /// </summary>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>True if the user has verified their email address, false if not.</returns>
        Task<bool> VerifyEmailAsync();

        /// <summary>
        ///     Sends an email to the user to verify that their email is valid to upload to gallery.
        ///     Must be logged in as the user to send.
        /// </summary>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>True if the verification email was sent successfully, false if not.</returns>
        Task<bool> SendVerificationEmailAsync();

        /// <summary>
        ///     Get all the albums associated with the account.
        ///     Must be logged in as the user to see secret and hidden albums.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of albums.</returns>
        Task<IAlbum[]> GetAlbumsAsync(string username = "me", int? page = null);

        /// <summary>
        ///     Get additional information about an album, this works the same as the Album Endpoint.
        /// </summary>
        /// <param name="id">The album's id.</param>
        /// <param name="username">The user account. Default: me</param>
		/// <exception cref="ArgumentNullException">Thrown when id or username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of albums.</returns>
        Task<IAlbum> GetAlbumAsync(string id, string username = "me");

        /// <summary>
        ///     Fetch an array of all of the album IDs.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of album ids.</returns>
        Task<string[]> GetAlbumIdsAsync(string username = "me", int? page = null);

        /// <summary>
        ///     Fetch the total number of albums associated with the account.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>The total number of albums associated with the account.</returns>
        Task<int> GetAlbumCountAsync(string username = "me");

        /// <summary>
        ///     Delete an Album with a given id.
        /// </summary>
        /// <param name="id">The album id.</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>True if the album was deleted successfully, false if not.</returns>
        Task<bool> DeleteAlbumAsync(string id);

        /// <summary>
        ///     Fetch the comments the user has created.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="commentSortOrder">'best', 'worst', 'oldest', or 'newest'. Defaults to 'newest'.</param>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of comments.</returns>
        Task<IComment[]> GetCommentsAsync(string username = "me",
            CommentSortOrder commentSortOrder = CommentSortOrder.Newest, int? page = null);

        /// <summary>
        ///     Fetch information about a specific comment.
        /// </summary>
        /// <param name="id">The comment id.</param>
        /// <param name="username">The user account. Default: me</param>
		/// <exception cref="ArgumentNullException">Thrown when id or username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of comments.</returns>
        Task<IComment> GetCommentAsync(string id, string username = "me");

        /// <summary>
        ///     Fetch an array of all of the comment IDs.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
        /// <param name="commentSortOrder">'best', 'worst', 'oldest', or 'newest'. Defaults to 'newest'.</param>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of comment IDs.</returns>
        Task<string[]> GetCommentIdsAsync(string username = "me",
            CommentSortOrder commentSortOrder = CommentSortOrder.Newest, int? page = null);

        /// <summary>
        ///     Fetch the total number of all of the comments associated with the account.
        /// </summary>
        /// <param name="username">The user account. Default: me</param>
		/// <exception cref="ArgumentNullException">Thrown when username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>The total number of comments associated with the account.</returns>
        Task<int> GetCommentCountAsync(string username = "me");

        /// <summary>
        ///     Delete a comment. You are required to be logged in as the user whom created the comment.
        /// </summary>
        /// <param name="id">The id of the comment to delete.</param>
		/// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>True if the comment was deleted successfully, false if not.</returns>
        Task<bool> DeleteCommentAsync(string id);

        /// <summary>
        ///     Fetch all of the images associated with the account.
        ///     You can page through the images by setting the page, this defaults to 0.
        /// </summary>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of images.</returns>
        Task<IImage[]> GetImagesAsync(int? page = null);

        /// <summary>
        ///     Return information about a specific image.
        /// </summary>
        /// <param name="id">The album's id.</param>
        /// <param name="username">The user account. Default: me</param>
		/// <exception cref="ArgumentNullException">Thrown when id or username was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An image.</returns>
        Task<IImage> GetImageAsync(string id, string username = "me");

        /// <summary>
        ///     Fetch an array of Image IDs that are associated with the account.
        /// </summary>
        /// <param name="page">Allows you to set the page number so you don't have to retrieve all the data at once.</param>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of image IDs.</returns>
        Task<string[]> GetImageIdsAsync(int? page = null);

        /// <summary>
        ///     Fetch the total number of images associated with the account.
        /// </summary>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>The total number of images associated with the account.</returns>
        Task<int> GetImageCountAsync();

        /// <summary>
        ///     Deletes an Image. This requires a delete hash rather than an ID.
        /// </summary>
        /// <param name="deleteHash"></param>
		/// <exception cref="ArgumentNullException">Thrown when id was null or empty.</exception>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>True if the image was deleted succesfully, false if not.</returns>
        Task<bool> DeleteImageAsync(string deleteHash);

        /// <summary>
        ///     Returns all of the notifications for the user.
        /// </summary>
        /// <param name="newNotifications">false for all notifications, true for only non-viewed notification. Default is true.</param>
		/// <exception cref="ImgurException">Thrown when Imgur encountered a problem.</exception>
        /// <returns>An array of notifications.</returns>
        Task<INotifications> GetNotificationsAsync(bool newNotifications = true);
    }
}
