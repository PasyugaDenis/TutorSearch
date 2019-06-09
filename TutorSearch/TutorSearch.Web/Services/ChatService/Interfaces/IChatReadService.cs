using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.ChatService
{
    public interface IChatReadService
    {
        Task<Chat> GetChatAsync(int id);

        Task<List<Message>> GetMessagesAsync(int id);

        Task<List<Chat>> GetUserChatsAsync(int userId); 
    }
}
