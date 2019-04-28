using System;
using System.Threading.Tasks;
using System.Web.Http;
using TutorSearch.Web.Helpers;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Services.TeacherService;
using TutorSearch.Web.Services.UserService;

namespace TutorSearch.Web.Controllers
{
    public class TeacherController : ApiController
    {
        private IUserReadService userReadService;
        private IUserWriteService userWriteService;

        private ITeacherReadService teacherReadService;
        private ITeacherWriteService teacherWriteService;

        public TeacherController(
            IUserReadService userReadService,
            IUserWriteService userWriteService,
            ITeacherReadService teacherReadService,
            ITeacherWriteService teacherWriteService)
        {
            this.userReadService = userReadService;
            this.userWriteService = userWriteService;

            this.teacherReadService = teacherReadService;
            this.teacherWriteService = teacherWriteService;
        }

        [HttpPost]
        public async Task<object> Edit(TeacherRequestModel model)
        {
            try
            {
                //Edit user
                var user = await userReadService.GetByIdAsync(model.Id);

                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Birthday = model.Birthday.Value;
                user.Email = model.Email;
                user.Phone = model.Phone;

                await userWriteService.EditUserAsync(user);

                //Edit teacher
                var teacher = await teacherReadService.GetByIdAsync(model.Id);

                teacher.Education = model.Education;
                teacher.Skill = model.Skill;
                teacher.WorkExperience = model.WorkExperience;
                teacher.IsPrivate = model.IsPrivate;
                teacher.City = model.City;

                await teacherWriteService.EditTeacherAsync(teacher);

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }
    }
}
