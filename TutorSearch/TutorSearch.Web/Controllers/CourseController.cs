using System.Threading.Tasks;
using System.Web.Http;
using TutorSearch.Web.Helpers;
using TutorSearch.Web.Models.Request;
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
            var courses = await courseReadService.GetListAsync(model);

            return JsonResults.Success(courses);
        }
    }
}