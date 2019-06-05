using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Repositories.CourseRepository;
using TutorSearch.Web.Repositories.RequestRepository;

namespace TutorSearch.Web.Services.CourseService
{
    public class CourseReadService : ICourseReadService
    {
        private ICourseReadRepository courseReadRepository;

        private IRequestReadRepository requestReadRepository;

        public CourseReadService(
            ICourseReadRepository courseReadRepository,
            IRequestReadRepository requestReadRepository)
        {
            this.courseReadRepository = courseReadRepository;
            this.requestReadRepository = requestReadRepository;
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var course = await courseReadRepository.GetAsync(id);

            return course;
        }

        public async Task<List<Course>> GetListAsync(CourseFilterRequest filter)
        {
            //filter
            var courses = await courseReadRepository.
                SearchAsync(filter.TeacherId, filter.IsClosed, filter.SearchValues);

            //sort
            courses = Sort(courses, filter.SortField, filter.SortAscending);

            return courses;
        }

        public async Task<List<Request>> GetCourseRequests(int courseId)
        {
            var result = await requestReadRepository.GetByCourseIdAsync(courseId);

            return result;
        }

        private List<Course> Sort(List<Course> courses, string sortField, bool sortAscending)
        {
            IOrderedEnumerable<Course> result;

            switch (sortField?.ToLower())
            {
                case "title":
                    result = sortAscending
                        ? courses.OrderBy(m => m.Title)
                        : courses.OrderByDescending(m => m.Title);
                    break;
                case "specialty":
                    result = sortAscending
                        ? courses.OrderBy(m => m.Specialty)
                        : courses.OrderByDescending(m => m.Specialty);
                    break;
                case "isclosed":
                    result = sortAscending
                        ? courses.OrderBy(m => m.IsClosed)
                        : courses.OrderByDescending(m => m.IsClosed);
                    break;
                case "id":
                default:
                    result = sortAscending
                        ? courses.OrderBy(m => m.Id)
                        : courses.OrderByDescending(m => m.Id);
                    break;
            }

            return result.ToList();
        }
    }
}
