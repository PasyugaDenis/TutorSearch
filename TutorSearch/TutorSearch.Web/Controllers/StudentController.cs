using System;
using System.Threading.Tasks;
using System.Web.Http;
using TutorSearch.Web.Helpers;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Services.StudentService;
using TutorSearch.Web.Services.UserService;

namespace TutorSearch.Web.Controllers
{
    public class StudentController : ApiController
    {
        private IUserReadService userReadService;
        private IUserWriteService userWriteService;

        private IStudentReadService studentReadService;
        private IStudentWriteService studentWriteService;

        public StudentController(
            IUserReadService userReadService,
            IUserWriteService userWriteService,
            IStudentReadService studentReadService,
            IStudentWriteService studentWriteService)
        {
            this.userReadService = userReadService;
            this.userWriteService = userWriteService;

            this.studentReadService = studentReadService;
            this.studentWriteService = studentWriteService;
        }

        [HttpGet]
        public async Task<object> ViewProfile(int userId)
        {
            var response = await studentReadService.ViewStudentByIdAsync(userId);

            if (response == null)
            {
                return JsonResults.Error(0, "User NotFound");
            }
            else
            {
                return JsonResults.Success(response);
            }
        }

        [HttpPost]
        public async Task<object> Edit(StudentRequest model)
        {
            try
            {
                //Edit user
                var user = await userReadService.GetByIdAsync(model.Id);

                user.Name = model.Name ?? "";
                user.Surname = model.Surname ?? "";
                user.Birthday = model.Birthday ?? new DateTime();
                user.Email = model.Email;
                user.Phone = model.Phone ?? "";

                await userWriteService.EditUserAsync(user);

                //Edit student
                var student = await studentReadService.GetByIdAsync(model.Id);

                student.Type = model.Type ?? "";
                student.Skill = model.Skill ?? "";
                student.Education = model.Education;
                student.Description = model.Description;

                await studentWriteService.EditStudentAsync(student);

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }
    }
}
