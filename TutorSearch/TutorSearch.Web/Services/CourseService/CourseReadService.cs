using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Repositories.CourseRepository;

namespace TutorSearch.Web.Services.CourseService
{
    public class CourseReadService : ICourseReadService
    {
        private ICourseReadRepository courseReadRepository;

        public CourseReadService(
            ICourseReadRepository courseReadRepository)
        {
            this.courseReadRepository = courseReadRepository;
        }

        public async Task<Course> GetCourse(int id)
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

        private List<Course> Sort(List<Course> courses, string sortField, bool sortAscending)
        {
            IOrderedEnumerable<Course> result;

            switch (sortField.ToLower())
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
