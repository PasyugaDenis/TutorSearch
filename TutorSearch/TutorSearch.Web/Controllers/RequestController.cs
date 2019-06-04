using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TutorSearch.Web.Helpers;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Services.RequestService;

namespace TutorSearch.Web.Controllers
{
    [RoutePrefix("api/Request")]
    public class RequestController : ApiController
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

        [Authorize]
        [HttpGet]
        [Route("Subscribe/{courseId:int}/{userId:int}")]
        public async Task<object> Subscribe(int courseId, int userId)
        {
            try
            {
                var request = new Request
                {
                    IsConfirmed = null,
                    IsClosed = false,
                    DateOfRegistration = DateTime.UtcNow,
                    Rating = null,
                    Comment = null,
                    StudentId = userId,
                    CourseId = courseId
                };

                var result = await requestWriteService.AddRequestAsync(request);

                return JsonResults.Success(result);
            }
            catch (Exception ex)
            {
                return JsonResults.Error(401, ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/Accept")]
        public async Task<object> Accept(int id)
        {
            try
            {
                await requestWriteService.AcceptAsync(id);

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(401, ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/Reject")]
        public async Task<object> Reject(int id)
        {
            try
            {
                await requestWriteService.RejectAsync(id);

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(401, ex.Message);
            }
        }

    }
}