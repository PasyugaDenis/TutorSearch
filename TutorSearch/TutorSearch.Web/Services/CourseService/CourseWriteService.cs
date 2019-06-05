using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.CourseRepository;

namespace TutorSearch.Web.Services.CourseService
{
    public class CourseWriteService : ICourseWriteService
    {
        private ICourseWriteRepository courseWriteRepository;

        public CourseWriteService(ICourseWriteRepository courseWriteRepository)
        {
            this.courseWriteRepository = courseWriteRepository;
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            var result = await courseWriteRepository.AddAsync(course);

            return result;
        }

        public async Task UpdateCourseAsync(Course course)
        {
            await courseWriteRepository.UpdateAsync(course);
        }

        public async Task DeleteCourseAsync(Course course)
        {
            await courseWriteRepository.RemoveAsync(course);
        }
    }
}
