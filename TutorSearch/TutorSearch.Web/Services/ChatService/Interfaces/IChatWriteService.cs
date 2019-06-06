using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.ChatService
{
    public interface IChatWriteService
    {
        Task UpdateChatAsync(Chat model);

        Task RemoveChatAsync(Chat model);

        Task SendMessageAsync(Message message);
    }
}
