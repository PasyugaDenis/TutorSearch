using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using TutorSearch.Helpers;
using TutorSearch.Models.Entities;
using TutorSearch.Models.Request;
using TutorSearch.Services.UserService;

namespace TutorSearch.Controllers
{
    [Route("api/UserController")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration settings;
        private IUserReadService userReadService;
        private IUserWriteService userWriteService;

        public UserController(
            IConfiguration settings,
            IUserReadService userReadService,
            IUserWriteService userWriteService)
        {
            this.settings = settings;

            this.userReadService = userReadService;
            this.userWriteService = userWriteService;
        }

        [Route("Registration")]
        [HttpPost]
        public async Task<ActionResult> Registration(UserRequestModel model)
        {
            var isUserContain = await userReadService.CheckUserByEmailAsync(model.Email);

            if (isUserContain)
            {
                return JsonResults.Error(0, "User is already registered");
            }
            else
            {
                try
                {
                    var newUser = await userWriteService.RegisterUserAsync(model);

                    var role = newUser.IsTeacher ? "Teacher" : "Student";

                    var identity = SignIn(newUser.Email, role);

                    var token = GetUserToken(identity);
                    var userId = newUser.Id;
                    var userRole = newUser.IsTeacher ? 1 : 0;

                    return JsonResults.Success(new { token, userId, userRole });
                }
                catch(Exception ex)
                {
                    return JsonResults.Error(0, ex.Message);
                }
            }
        }

        [Route("Authorization")]
        [HttpPost]
        public async Task<ActionResult> Authorization(AuthorizationRequestModel model)
        {
            var user = await userReadService.CheckAuthorizationUser(model.Email, model.Password);

            if (user == null)
            {
                return JsonResults.Error(0, "User not registered");
            }
            else
            {
                try
                {
                    var role = user.IsTeacher ? "Teacher" : "Student";

                    var identity = SignIn(user.Email, role);

                    var token = GetUserToken(identity);
                    var userId = user.Id;
                    var userRole = user.IsTeacher ? 1 : 0;

                    return JsonResults.Success(new { token, userId, userRole });
                }
                catch (Exception ex)
                {
                    return JsonResults.Error(0, ex.Message);
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
                audience: settings["SiteUrl"],
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}