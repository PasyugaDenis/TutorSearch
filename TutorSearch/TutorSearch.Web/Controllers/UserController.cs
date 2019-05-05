using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using TutorSearch.Web.Helpers;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Services.ContactService;
using TutorSearch.Web.Services.StudentService;
using TutorSearch.Web.Services.TeacherService;
using TutorSearch.Web.Services.UserService;

namespace TutorSearch.Web.Controllers
{
    public class UserController : ApiController
    {
        private TutorSearchConfiguration settings;

        private IUserReadService userReadService;
        private IUserWriteService userWriteService;

        private IStudentReadService studentReadService;
        private IStudentWriteService studentWriteService;

        private ITeacherReadService teacherReadService;
        private ITeacherWriteService teacherWriteService;

        private IContactWriteService contactWriteService;

        public UserController(
            TutorSearchConfiguration settings,
            IUserReadService userReadService,
            IUserWriteService userWriteService,
            IStudentReadService studentReadService,
            IStudentWriteService studentWriteService,
            ITeacherReadService teacherReadService,
            ITeacherWriteService teacherWriteService,
            IContactWriteService contactWriteService)
        {
            this.settings = settings;

            this.userReadService = userReadService;
            this.userWriteService = userWriteService;

            this.studentReadService = studentReadService;
            this.studentWriteService = studentWriteService;

            this.teacherReadService = teacherReadService;
            this.teacherWriteService = teacherWriteService;

            this.contactWriteService = contactWriteService;
        }

        [HttpGet]
        public string Index()
        {
            return "Tutor Search";
        }

        [HttpPost]
        public async Task<object> Registration(UserRequest model)
        {
            if (String.IsNullOrEmpty(model.Password.Trim()))
            {
                return JsonResults.Error(415, "Enter your Password.");
            }

            if (model.Password.Length < 5)
            {
                return JsonResults.Error(415, "Password must not be shorter than 6 characters.");
            }

            var isUserContain = await userReadService.CheckUserByEmailAsync(model.Email);

            if (isUserContain)
            {
                return JsonResults.Error(401, "User is already registered");
            }
            else
            {
                try
                {
                    string role;

                    var user = new User
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email,
                        Password = userWriteService.HashPassword(model.Password),
                        IsTeacher = model.IsTeacher
                    };

                    if (model.IsTeacher)
                    {
                        role = "Teacher";

                        var contacts = await contactWriteService.AddContactAsync();

                        user.Teacher = new Teacher
                        {
                            ContactsId = contacts.Id
                        };
                    }
                    else
                    {
                        role = "Student";

                        user.Student = new Student();
                    }

                    var newUser = await userWriteService.RegisterUserAsync(user);

                    var identity = SignIn(newUser.Email, role);

                    var token = GetUserToken(identity);
                    var userId = newUser.Id;
                    var userRole = newUser.IsTeacher ? 1 : 0;

                    return JsonResults.Success(new { token, userId, userRole });
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            return JsonResults.Error(415, ve.ErrorMessage);
                        }
                    }

                    return JsonResults.Error("Trable with validation data");
                }
                catch (Exception ex)
                {
                    return JsonResults.Error(400, ex.Message);
                }
            }
        }

        [HttpPost]
        public async Task<object> Authorization(AuthorizationRequest model)
        {
            var user = await userReadService.SearchAuthorizationUserAsync(model.Email);

            if (user == null)
            {
                return JsonResults.Error(401, "User not registered");
            }
            else
            {
                try
                {
                    var isCorrectPassword = userReadService.CheckUserCorrectPassword(model.Password, user.Password);

                    if (!isCorrectPassword)
                    {
                        return JsonResults.Error(402, "Incorrect password");
                    }

                    var role = user.IsTeacher ? "Teacher" : "Student";

                    var identity = SignIn(user.Email, role);

                    var token = GetUserToken(identity);
                    var userId = user.Id;
                    var userRole = user.IsTeacher ? 1 : 0;

                    return JsonResults.Success(new { token, userId, userRole });
                }
                catch (Exception ex)
                {
                    return JsonResults.Error(400, ex.Message);
                }
            }
        }

        //Utills
        private ClaimsIdentity SignIn(string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }

        private string GetUserToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: settings.SiteUrl,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
