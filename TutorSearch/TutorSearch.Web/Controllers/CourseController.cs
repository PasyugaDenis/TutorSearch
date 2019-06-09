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
using TutorSearch.Web.Services.RequestService;

namespace TutorSearch.Web.Controllers
{
    [RoutePrefix("api/Course")]
    public class CourseController : ApiController
    {
        private ICourseReadService courseReadService;
        private ICourseWriteService courseWriteService;
        private IRequestReadService requestReadService;
        private IRequestWriteService requestWriteService;

        public CourseController(
            ICourseReadService courseReadService,
            ICourseWriteService courseWriteService,
            IRequestReadService requestReadService,
            IRequestWriteService requestWriteService)
        {
            this.courseReadService = courseReadService;
            this.courseWriteService = courseWriteService;
            this.requestReadService = requestReadService;
            this.requestWriteService = requestWriteService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
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
                    TutorName = item.Teacher.User.Name,
                    TutorSurname = item.Teacher.User.Surname,
                    City = item.Teacher.City,
                    Specialty = item.Specialty,
                    IsClosed = item.IsClosed,
                    Description = item.Description
                });
            }

            return JsonResults.Success(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<object> GetCourse(int id)
        {
            var course = await courseReadService.GetCourseAsync(id);

            if (course == null)
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

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public async Task<object> AddCourse(CourseRequest model)
        {
            if (!ModelState.IsValid)
            {
                return JsonResults.Error(400, ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }

            if (model.TeacherId == 0)
            {
                return JsonResults.Error(400, "TeacherId is required");
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

                await courseWriteService.AddCourseAsync(course);

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Edit")]
        public async Task<object> EditCourse(CourseRequest model)
        {
            if (!ModelState.IsValid)
            {
                return JsonResults.Error(400, ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }

            try
            {
                var course = await courseReadService.GetCourseAsync(model.Id);

                if (course == null)
                {
                    return JsonResults.Error(404, "Course not found");
                }

                course.Title = model.Title;
                course.Specialty = model.Specialty;
                course.IsClosed = model.IsClosed;
                course.Description = model.Description;

                await courseWriteService.UpdateCourseAsync(course);

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Requests/{courseId:int}")]
        public async Task<object> GetRequests(int courseId)
        {
            var result = new List<RequestViewModel>();

            var requests = await courseReadService.GetCourseRequestsAsync(courseId);

            requests.ForEach(m => result.Add(new RequestViewModel
            {
                Id = m.Id,
                IsConfirmed = m.IsConfirmed,
                IsClosed = m.IsClosed,
                DateOfRegistration = m.DateOfRegistration,
                Rating = m.Rating,
                Comment = m.Comment,
                StudentFullName = $"{m.Student.User.Name} {m.Student.User.Surname}"
            }));

            return JsonResults.Success(result);
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/Delete")]
        public async Task<object> DeleteCourse(int id)
        {
            try
            {
                var course = await courseReadService.GetCourseAsync(id);
                if (course == null)
                {
                    return JsonResults.Error(404, "Course not found");
                }

                var requests = await requestReadService.GetRequestsByCourseIdAsync(id);
                foreach (var request in requests)
                {
                    await requestWriteService.RemoveRequestAsync(request);
                }

                await courseWriteService.RemoveCourseAsync(course);

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }
    }
}