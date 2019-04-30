using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.CourseRepository
{
    public interface ICourseWriteRepository
    {
        Task<Course> AddAsync(Course course);

        Task UpdateAsync(Course course);

        Task RemoveAsync(Course course);
    }
}
