using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Response;
using TutorSearch.Web.Repositories.TeacherRepository;
using TutorSearch.Web.Repositories.UserRepository;

namespace TutorSearch.Web.Services.TeacherService
{
    public class TeacherReadService : ITeacherReadService
    {
        private ITeacherReadRepository teacherReadRepository;
        private IUserReadRepository userReadRepository;

        public TeacherReadService(
            ITeacherReadRepository teacherReadRepository,
            IUserReadRepository userReadRepository)
        {
            this.teacherReadRepository = teacherReadRepository;
            this.userReadRepository = userReadRepository;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var model = await teacherReadRepository.GetAsync(id);

            return model;
        }

        public async Task<TeacherViewModel> ViewTeacherByIdAsync(int id)
        {
            var teacher = await teacherReadRepository.GetAsync(id);
            var user = await userReadRepository.GetAsync(id);

            if (teacher == null || user == null)
                return null;

            TeacherViewModel teacherViewModel = new TeacherViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Birthday = user.Birthday,
                Email = user.Email,
                Phone = user.Phone,
                isTeacher = user.IsTeacher,
                Education = teacher.Education,
                Skill = teacher.Skill,
                WorkExperience = teacher.WorkExperience,
                IsPrivate = teacher.IsPrivate,
                Description = teacher.Description,
                City = teacher.City
            };

            return teacherViewModel;
        }
    }
}