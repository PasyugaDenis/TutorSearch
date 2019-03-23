using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.CourseRepository
{
    public interface ICourseWriteRepository
    {
        Task AddAsync(Course course);

        Task UpdateAsync(Course course);

        Task RemoveAsync(Course course);
    }
}
