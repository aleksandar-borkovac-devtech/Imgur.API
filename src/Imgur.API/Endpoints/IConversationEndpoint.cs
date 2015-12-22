using System.Threading.Tasks;
using Imgur.API.Models;

namespace Imgur.API.Endpoints
{
	/// <summary>
	///  Converation related endpoints.
	/// </summary>
	public interface IConversationEndpoint : IEndpoint
    {
        /// <summary>
        /// Get list of all conversations for the logged in user.
        /// </summary>
        /// <returns></returns>
		Task<IConversation[]> GetConversationListAsync();

        /// <summary>
        /// Get information about a specific conversation. Includes messages.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        Task<IConversation> GetConversationAsync(int id, uint page = 1, uint offset=0);
		
        /// <summary>
        /// Sends a new message.
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="body"></param>
        /// <returns></returns>
		Task<bool> SendMessageAsync(string recipient, string body);

        /// <summary>
        /// Delete a conversation by the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteConversation(int id);

        /// <summary>
        /// Report a user for sending messages that are against the Terms of Service.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<bool> ReportSenderAsync(string username);

        /// <summary>
        /// Block the user from sending messages to the user that is logged in.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<bool> BlockSenderAsync(string username);
	}
}
