using Microsoft.AspNetCore.Mvc;
using TutorSearch.Services.RequestService;

namespace TutorSearch.Controllers
{
    [Route("api/RequestController")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private IRequestReadService requestReadService;
        private IRequestWriteService requestWriteService;

        public RequestController(
            IRequestReadService requestReadService,
            IRequestWriteService requestWriteService)
        {
            this.requestReadService = requestReadService;
            this.requestWriteService = requestWriteService;
        }
    }
}