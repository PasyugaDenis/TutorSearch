using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TutorSearch.Web.Helpers;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Models.Response;
using TutorSearch.Web.Services.ChatService;

namespace TutorSearch.Web.Controllers
{
    [RoutePrefix("api/Chat")]
    public class ChatController : ApiController
    {
        private IChatReadService chatReadService;
        private IChatWriteService chatWriteService;

        public ChatController(
            IChatReadService chatReadService,
            IChatWriteService chatWriteService)
        {
            this.chatReadService = chatReadService;
            this.chatWriteService = chatWriteService;
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<object> GetChat(int id)
        {
            var course = await chatReadService.GetChatAsync(id);

            if (course == null)
            {
                return JsonResults.Error(404, "Course not found");
            }

            var result = new ChatViewModel
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                IsBlocked = course.IsBlocked
            };

            return JsonResults.Success(result);
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/Messages")]
        public async Task<object> GetChatMessages(int id)
        {
            var result = new List<MessageViewModel>();

            var messages = await chatReadService.GetMessagesAsync(id);

            messages.ForEach(m => result.Add(new MessageViewModel
            {
                Id = m.Id,
                Text = m.Text,
                IsRead = m.IsRead,
                FromUserId = m.FromUserId,
                ToUserId = m.ToUserId,
                ChatId = m.ChatId,
                AuthorName = $"{m.FromUser.Name} {m.FromUser.Surname}"
            }));

            return JsonResults.Success(result);
        }

        [Authorize]
        [HttpPost]
        [Route("Edit")]
        public async Task<object> EditChat(ChatRequest model)
        {
            try
            {
                var chat = await chatReadService.GetChatAsync(model.Id);

                if (chat == null)
                {
                    return JsonResults.Error(404, "Chat not found");
                }

                chat.Title = model.Title;
                chat.Description = model.Description;
                chat.IsBlocked = model.IsBlocked;

                await chatWriteService.UpdateChatAsync(chat);

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/Remove")]
        public async Task<object> RemoveChat(int id)
        {
            try
            {
                var chat = await chatReadService.GetChatAsync(id);

                if (chat == null)
                {
                    return JsonResults.Error(404, "Chat not found");
                }

                await chatWriteService.RemoveChatAsync(chat);

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Send")]
        public async Task<object> SendMessage(MessageRequest model)
        {
            try
            {
                var message = new Message
                {
                    Text = model.Text,
                    IsRead = model.IsRead,
                    FromUserId = model.FromUserId,
                    ToUserId = model.ToUserId,
                    ChatId = model.ChatId
                };

                await chatWriteService.SendMessageAsync(message);

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }
    }
}