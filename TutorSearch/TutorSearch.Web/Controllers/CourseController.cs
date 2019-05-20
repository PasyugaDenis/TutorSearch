using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TutorSearch.Web.Helpers;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Models.Response;
using TutorSearch.Web.Services.CourseService;

namespace TutorSearch.Web.Controllers
{
    [Authorize]
    public class CourseController : ApiController
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

        [HttpPost]
        public async Task<object> GetList(CourseFilterRequest model)
        {
            var result = new List<CourseViewModel>();

            var list = await courseReadService.GetListAsync(model);

            foreach (var item in list)
            {
                result.Add(new CourseViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Specialty = item.Specialty,
                    IsClosed = item.IsClosed,
                    Description = item.Description
                });
            }

            return JsonResults.Success(result);
        }
        
        [HttpGet]
        public async Task<object> GetCourse(int id)
        {
            var course = await courseReadService.GetByIdAsync(id);

            if(course == null)
            {
                return JsonResults.Error(404, "Course not found");
            }

            var result = new CourseViewModel
            {
                Id = course.Id,
                Title = course.Title,
                TutorName = course.Teacher.User.Name,
                TutorSurname = course.Teacher.User.Surname,
                City = course.Teacher.City,
                Specialty = course.Specialty,
                IsClosed = course.IsClosed,
                Description = course.Description
            };

            return JsonResults.Success(result);
        }

        [HttpPost]
        public async Task<object> AddCourse(CourseRequest model)
        {
            if (!ModelState.IsValid)
            {
                return JsonResults.Error(400, ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }

            try
            {
                var course = new Course
                {
                    Title = model.Title,
                    TeacherId = model.TeacherId,
                    Specialty = model.Specialty,
                    IsClosed = model.IsClosed,
                    Description = model.Description
                };

                var newCourse = await courseWriteService.AddAsync(course);

                var result = new CourseViewModel
                {
                    Id = newCourse.Id,
                    Title = newCourse.Title,
                    TutorName = newCourse.Teacher.User.Name,
                    TutorSurname = newCourse.Teacher.User.Surname,
                    City = newCourse.Teacher.City,
                    Specialty = newCourse.Specialty,
                    IsClosed = newCourse.IsClosed,
                    Description = newCourse.Description
                };

                return JsonResults.Success(result);
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }
    }
}