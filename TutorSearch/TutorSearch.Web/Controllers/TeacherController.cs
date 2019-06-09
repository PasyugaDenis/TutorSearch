using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TutorSearch.Web.Helpers;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Models.Response;
using TutorSearch.Web.Services.ContactService;
using TutorSearch.Web.Services.TeacherService;
using TutorSearch.Web.Services.UserService;
using TutorSearch.Web.Services.CourseService;

namespace TutorSearch.Web.Controllers
{
    [RoutePrefix("api/Teacher")]
    public class TeacherController : ApiController
    {
        private IUserReadService userReadService;
        private IUserWriteService userWriteService;

        private ITeacherReadService teacherReadService;
        private ITeacherWriteService teacherWriteService;

        private IContactReadService contactsReadService;
        private IContactWriteService contactsWriteService;

        private ICourseReadService courseReadService;

        public TeacherController(
            IUserReadService userReadService,
            IUserWriteService userWriteService,
            ITeacherReadService teacherReadService,
            ITeacherWriteService teacherWriteService,
            IContactReadService contactsReadService,
            IContactWriteService contactsWriteService,
            ICourseReadService courseReadService)
        {
            this.userReadService = userReadService;
            this.userWriteService = userWriteService;

            this.teacherReadService = teacherReadService;
            this.teacherWriteService = teacherWriteService;

            this.contactsReadService = contactsReadService;
            this.contactsWriteService = contactsWriteService;

            this.courseReadService = courseReadService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<object> ViewProfile(int id)
        {
            var user = await userReadService.GetUserAsync(id);

            if (user != null && user.IsTeacher)
            {
                var userContacts = await contactsReadService.GetContactAsync(user.Teacher.ContactsId);

                var contacts = new ContactsViewModel
                {
                    Skype = userContacts.Skype,
                    Telegram = userContacts.Telegram,
                    Facebook = userContacts.Facebook,
                    Viber = userContacts.Viber,
                    WhatsUp = userContacts.WhatsUp,
                };

                var countDaysOfYear = DateTime.IsLeapYear(DateTime.UtcNow.Year) ? 366 : 365;

                var result = new TeacherViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Birthday = user.Birthday,
                    Phone = user.Phone,
                    Email = user.Email,
                    IsTeacher = user.IsTeacher,
                    Age = ((DateTime.UtcNow - user.Birthday).Days / countDaysOfYear),
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

        [Authorize]
        [HttpPost]
        [Route("Edit")]
        public async Task<object> Edit(TeacherRequest model)
        {
            if (!ModelState.IsValid)
            {
                return JsonResults.Error(400, ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }

            try
            {
                //Edit user
                var user = await userReadService.GetUserAsync(model.Id);

                var isCorrectEmail = await CheckEmailAsync(user.Email, model.Email);

                if (!isCorrectEmail)
                {
                    return JsonResults.Error(400, "Incorrect email");
                }

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
                    var contacts = await contactsReadService.GetContactAsync(user.Teacher.ContactsId);

                    contacts.Skype = model.Contacts.Skype;
                    contacts.Telegram = model.Contacts.Telegram;
                    contacts.Facebook = model.Contacts.Facebook;
                    contacts.Viber = model.Contacts.Viber;
                    contacts.WhatsUp = model.Contacts.WhatsUp;
                    
                    await contactsWriteService.UpdateContactAsync(contacts);
                }

                return JsonResults.Success();
            }
            catch (Exception ex)
            {
                return JsonResults.Error(400, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<object> GetList(TeacherFilterRequest model)
        {
            var result = new List<TeacherViewModel>();

            var list = await teacherReadService.GetListAsync(model);

            var countDaysOfYear = DateTime.IsLeapYear(DateTime.UtcNow.Year) ? 366 : 365;

            foreach (var item in list)
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
                    IsTeacher = item.User.IsTeacher,
                    Description = item.Description,
                    Age = ((DateTime.UtcNow - item.User.Birthday).Days / countDaysOfYear)
                });
            }

            return JsonResults.Success(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Requests/{userId:int}")]
        public async Task<object> GetRequests(int userId)
        {
            var result = new List<RequestViewModel>();

            var requests = await courseReadService.GetTeacherCourseRequestsAsync(userId);

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

        //Utills
        private async Task<bool> CheckEmailAsync(string oldEmail, string newEmail)
        {
            if (oldEmail != newEmail)
            {
                var isUserRegistred = await userReadService.CheckUserByEmailAsync(newEmail);

                if (isUserRegistred)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
