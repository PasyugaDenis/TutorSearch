using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.ChatRepository;
using TutorSearch.Web.Repositories.MessageRepository;
using TutorSearch.Web.Repositories.UserRepository;

namespace TutorSearch.Web.Services.ChatService
{
    public class ChatWriteService : IChatWriteService
    {
        private IUserReadRepository userReadRepository;

        private IChatReadRepository chatReadRepository;
        private IChatWriteRepository chatWriteRepository;

        private IMessageReadRepository messageReadRepository;
        private IMessageWriteRepository messageWriteRepository;

        public ChatWriteService(
            IUserReadRepository userReadRepository,
            IChatReadRepository chatReadRepository,
            IChatWriteRepository chatWriteRepository,
            IMessageReadRepository messageReadRepository,
            IMessageWriteRepository messageWriteRepository)
        {
            this.userReadRepository = userReadRepository;

            this.chatReadRepository = chatReadRepository;
            this.chatWriteRepository = chatWriteRepository;

            this.messageReadRepository = messageReadRepository;
            this.messageWriteRepository = messageWriteRepository;
        }

        public async Task UpdateChatAsync(Chat chat)
        {
            await chatWriteRepository.UpdateAsync(chat);
        }

        public async Task RemoveChatAsync(Chat chat)
        {
            var messages = await messageReadRepository.GetAllByChatIdAsync(chat.Id);

            messages.ForEach(async m =>
            {
                await messageWriteRepository.RemoveAsync(m);
            });

            await chatWriteRepository.RemoveAsync(chat);
        }

        public async Task SendMessageAsync(Message message)
        {
            var chat = await chatReadRepository.GetAsync(message.ChatId);

            if (chat == null)
            {
                chat = await CreateChatAsync(message);
            }

            message.ChatId = chat.Id;

            await messageWriteRepository.AddAsync(message);
        }


        private async Task<Chat> CreateChatAsync(Message message)
        {
            var fromUser = await userReadRepository.GetAsync(message.FromUserId);
            var toUser = await userReadRepository.GetAsync(message.ToUserId);

            var model = new Chat
            {
                Title = $"{fromUser.Name} - {toUser.Name}"
            };

            var newChat = await chatWriteRepository.AddAsync(model);

            return newChat;
        }
    }
}
