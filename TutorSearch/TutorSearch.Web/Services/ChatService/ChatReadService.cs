using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.ChatRepository;
using TutorSearch.Web.Repositories.MessageRepository;

namespace TutorSearch.Web.Services.ChatService
{
    public class ChatReadService : IChatReadService
    {
        private IChatReadRepository chatReadRepository;

        private IMessageReadRepository messageReadRepository;

        public ChatReadService(
            IChatReadRepository chatReadRepository,
            IMessageReadRepository messageReadRepository)
        {
            this.chatReadRepository = chatReadRepository;

            this.messageReadRepository = messageReadRepository;
        }

        public async Task<Chat> GetChatAsync(int id)
        {
            var result = await chatReadRepository.GetAsync(id);

            return result;
        }

        public async Task<List<Message>> GetMessagesAsync(int chatId)
        {
            var result = await messageReadRepository.GetAllByChatIdAsync(chatId);

            return result;
        }

        public async Task<List<Chat>> GetUserChatsAsync(int userId)
        {
            var chats = await chatReadRepository.GetAllAsync();
            var messages = await messageReadRepository.GetUserMessagesAsync(userId);

            var chatIds = messages.Select(m => m.ChatId).Distinct();

            var result = chats.Where(m => chatIds.Contains(m.Id)).ToList();

            return result;
        }
    }
}
