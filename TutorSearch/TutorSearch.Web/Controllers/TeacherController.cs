using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TutorSearch.Web.Helpers;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Models.Response;
using TutorSearch.Web.Services.ContactService;
using TutorSearch.Web.Services.TeacherService;
using TutorSearch.Web.Services.UserService;

namespace TutorSearch.Web.Controllers
{
    [Authorize]
    public class TeacherController : ApiController
    {
        private IUserReadService userReadService;
        private IUserWriteService userWriteService;

        private ITeacherReadService teacherReadService;
        private ITeacherWriteService teacherWriteService;

        private IContactReadService contactsReadService;
        private IContactWriteService contactsWriteService;

        public TeacherController(
            IUserReadService userReadService,
            IUserWriteService userWriteService,
            ITeacherReadService teacherReadService,
            ITeacherWriteService teacherWriteService,
            IContactReadService contactsReadService,
            IContactWriteService contactsWriteService)
        {
            this.userReadService = userReadService;
            this.userWriteService = userWriteService;

            this.teacherReadService = teacherReadService;
            this.teacherWriteService = teacherWriteService;

            this.contactsReadService = contactsReadService;
            this.contactsWriteService = contactsWriteService;
        }

        [HttpGet]
        public async Task<object> ViewProfile(int id)
        {
            var user = await userReadService.GetByIdAsync(id);

            if (user != null && user.IsTeacher)
            {
                var userContacts = await contactsReadService.GetByIdAsync(user.Teacher.ContactsId);

                var contacts = new ContactsViewModel
                {
                    Skype = userContacts.Skype,
                    Telegram = userContacts.Telegram,
                    Facebook = userContacts.Facebook,
                    Viber = userContacts.Viber,
                    WhatsUp = userContacts.WhatsUp,
                };

                var result = new TeacherViewModel
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Birthday = user.Birthday,
                    Phone = user.Phone,
                    Email = user.Email,
                    IsTeacher = user.IsTeacher,
                    Education = user.Teacher.Education,
                    Skill = user.Teacher.Skill,
                    City = user.Teacher.City,
                    Description = user.Teacher.Description,
                    IsPrivate = user.Teacher.IsPrivate,
                    WorkExperience = user.Teacher.WorkExperience,
                    Contacts = contacts
                };

                return JsonResults.Success(result);
            }
            else
            {
                return JsonResults.Error(0, "Teacher not found");
            }
        }

        [HttpPost]
        public async Task<object> Edit(TeacherRequest model)
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

                user.Teacher.Education = model.Education;
                user.Teacher.Skill = model.Skill;
                user.Teacher.WorkExperience = model.WorkExperience;
                user.Teacher.IsPrivate = model.IsPrivate;
                user.Teacher.City = model.City;
                user.Teacher.Description = model.Description;

                await userWriteService.UpdateUserAsync(user);

                //Edit contacts

                if (model.Contacts != null)
                {
                    var contacts = await contactsReadService.GetByIdAsync(user.Teacher.ContactsId);
                    contacts.Skype = model.Contacts.Skype;
                    contacts.Telegram = model.Contacts.Telegram;
                    contacts.Facebook = model.Contacts.Facebook;
                    contacts.Viber = model.Contacts.Viber;
                    contacts.WhatsUp = model.Contacts.WhatsUp;
                    
                    await contactsWriteService.UpdateContactsAsync(contacts);
                }
                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<object> GetList(TeacherFilterRequest model)
        {
            var result = new List<TeacherViewModel>();

            var list = await teacherReadService.GetListAsync(model);

            foreach(var item in list)
            {
                result.Add(new TeacherViewModel
                {
                    Id = item.User.Id,
                    Name = item.User.Name,
                    Surname = item.User.Surname,
                    Birthday = item.User.Birthday,
                    Email = item.User.Email,
                    Phone = item.User.Phone,
                    Education = item.Education,
                    Skill = item.Skill,
                    City = item.City,
                    IsPrivate = item.IsPrivate,
                    WorkExperience = item.WorkExperience,
                    IsTeacher = item.User.IsTeacher
                });
            }

            return JsonResults.Success(result);
        }

        [HttpGet]
        public async Task<object> GetTeacher(int id)
        {
            var teacher = await teacherReadService.GetByIdAsync(id);

            if(teacher == null)
            {
                return JsonResults.Error(404, "Teacher not found");
            }

            var contacts = new ContactsViewModel
            {
                Skype = teacher.Contacts.Skype,
                Telegram = teacher.Contacts.Telegram,
                Facebook = teacher.Contacts.Facebook,
                Viber = teacher.Contacts.Viber,
                WhatsUp = teacher.Contacts.WhatsUp
            };

            var result = new TeacherPageViewModel
            {
                Id = teacher.User.Id,
                Name = teacher.User.Name,
                Surname = teacher.User.Surname,
                Age = ((DateTime.Now - teacher.User.Birthday).Days / 365),
                Email = teacher.User.Email,
                Education = teacher.Education,
                Skill = teacher.Skill,
                City = teacher.City,
                WorkExperience = teacher.WorkExperience,
                Description = teacher.Description,
                IsPrivate = teacher.IsPrivate,
                Phone = teacher.User.Phone,
                Contacts = contacts
            };

            return JsonResults.Success(result);
        }
    }
}
