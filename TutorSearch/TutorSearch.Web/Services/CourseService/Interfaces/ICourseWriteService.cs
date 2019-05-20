using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.CourseService
{
    public interface ICourseWriteService
    {
        Task<Course> AddAsync(Course course);
    }
}
