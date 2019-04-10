using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.CourseRepository
{
    public interface ICourseReadRepository
    {
        Task<Course> GetAsync(int id);

        Task<List<Course>> GetAllAsync();
    }
}
