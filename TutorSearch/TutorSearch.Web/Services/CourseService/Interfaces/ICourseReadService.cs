using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Request;

namespace TutorSearch.Web.Services.CourseService
{
    public interface ICourseReadService
    {
        Task<List<Course>> GetListAsync(CourseFilterRequest filter);

        Task<Course> GetCourseAsync(int id);

        Task<List<Request>> GetCourseRequestsAsync(int courseId);
    }
}
