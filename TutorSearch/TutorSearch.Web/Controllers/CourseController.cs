using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TutorSearch.Web.Helpers;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Models.Response;
using TutorSearch.Web.Services.CourseService;

namespace TutorSearch.Web.Controllers
{
    public class CourseController : ApiController
    {
        private ICourseReadService courseReadService;
        private ICourseWriteService courseWriteService;

        public CourseController(
            ICourseReadService courseReadService,
            ICourseWriteService courseWriteService)
        {
            this.courseReadService = courseReadService;
            this.courseWriteService = courseWriteService;
        }

        [HttpPost]
        public async Task<object> GetList(CourseFilterRequest model)
        {
            List<CourseViewModel> result = new List<CourseViewModel>();

            var list = await courseReadService.GetListAsync(model);

            foreach (var item in list)
            {
                result.Add(new CourseViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Specialty = item.Specialty,
                    IsClosed = item.IsClosed,
                    Description = item.Description
                });
            }

            return JsonResults.Success(result);
        }
    }
}