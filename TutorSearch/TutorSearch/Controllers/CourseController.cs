using Microsoft.AspNetCore.Mvc;
using TutorSearch.Services.CourseService;

namespace TutorSearch.Controllers
{
    [Route("api/CourseController")]
    [ApiController]
    public class CourseController : ControllerBase
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
    }
}