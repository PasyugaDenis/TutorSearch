﻿using System.Threading.Tasks;
using TutorSearch.Models.Response;
using TutorSearch.Repositories.TeacherRepository;
using TutorSearch.Repositories.UserRepository;

namespace TutorSearch.Services.TeacherService
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
                Type = teacher.Type,
                Skill = teacher.Skill,
                WorkExperience = teacher.WorkExperience,
                IsPrivate = teacher.IsPrivate,
                Description = teacher.Description
            };
            
            return teacherViewModel;
        }
    }
}
