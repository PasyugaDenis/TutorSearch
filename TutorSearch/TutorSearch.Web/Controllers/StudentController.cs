﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using TutorSearch.Web.Helpers;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Models.Response;
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
            var user = await userReadService.GetByIdAsync(userId);

            if (user != null && !user.IsTeacher)
            {
                var result = new StudentViewModel
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Birthday = user.Birthday,
                    Phone = user.Phone,
                    Email = user.Email,
                    IsTeacher = user.IsTeacher,
                    Type = user.Student.Type,
                    Skill = user.Student.Skill,
                    Education = user.Student.Education,
                    Description = user.Student.Description
                };

                return JsonResults.Success(result);
            }
            else
            {
                return JsonResults.Error(0, "Student not found");
            }
        }

        [HttpPost]
        public async Task<object> Edit(StudentRequest model)
        {
            try
            {
                //Edit user
                var user = await userReadService.GetByIdAsync(model.Id);

                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Birthday = model.Birthday ?? new DateTime();
                user.Email = model.Email;
                user.Phone = model.Phone;

                user.Student.Type = model.Type;
                user.Student.Skill = model.Skill;
                user.Student.Education = model.Education;
                user.Student.Description = model.Description;

                await userWriteService.UpdateUserAsync(user);

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }
    }
}
