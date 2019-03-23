using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.CourseRepository
{
    public interface ICourseReadRepository
    {
        Task<Course> GetAsync(int id);

        Task<List<Course>> GetAllAsync();
    }
}
