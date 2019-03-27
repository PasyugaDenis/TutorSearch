using Microsoft.AspNetCore.Mvc;
using TutorSearch.Services.UserService;

namespace TutorSearch.Controllers
{
    [Route("api/UserController")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserReadService userReadService;
        private IUserWriteService userWriteService;

        public UserController(
            IUserReadService userReadService, 
            IUserWriteService userWriteService)
        {
            this.userReadService = userReadService;
            this.userWriteService = userWriteService;
        }
    }
}