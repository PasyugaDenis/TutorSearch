using Microsoft.AspNetCore.Mvc;
using TutorSearch.Services.ChatService;

namespace TutorSearch.Controllers
{
    [Route("api/ChatController")]
    [ApiController]
    public class ChatController : ControllerBase
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
    }
}