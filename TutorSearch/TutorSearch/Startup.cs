using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TutorSearch.Repositories.ChatRepository;
using TutorSearch.Repositories.ContactRepository;
using TutorSearch.Repositories.CourseRepository;
using TutorSearch.Repositories.MessageRepository;
using TutorSearch.Repositories.RequestRepository;
using TutorSearch.Repositories.StudentRepository;
using TutorSearch.Repositories.TeacherRepository;
using TutorSearch.Repositories.UserRepository;

namespace TutorSearch
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath);

#if DEBUG 
            builder.AddXmlFile("config.Debug.xml");
#else
            builder.AddXmlFile("config.Release.xml");
#endif

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //bind repositories
            BindRepositories(services);

            //bind services
            BindServices(services);

            //set config
            services.AddTransient(provider => Configuration);

            //set DbContext
            string connection = Configuration["DBConnectionString"];
            services.AddDbContext<TutorSearchContext>(options => options.UseSqlServer(connection));

            //set MVC
            services.AddMvc();

            //set Authentification
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = Configuration["SiteUrl"],
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private void BindServices(IServiceCollection services)
        {
        }

        private void BindRepositories(IServiceCollection services)
        {
            services.AddTransient<IChatReadRepository, ChatReadRepository>();
            services.AddTransient<IChatWriteRepository, ChatWriteRepository>();

            services.AddTransient<IContactReadRepository, ContactReadRepository>();
            services.AddTransient<IContactWriteRepository, ContactWriteRepository>();

            services.AddTransient<ICourseReadRepository, CourseReadRepository>();
            services.AddTransient<ICourseWriteRepository, CourseWriteRepository>();

            services.AddTransient<IMessageReadRepository, MessageReadRepository>();
            services.AddTransient<IMessageWriteRepository, MessageWriteRepository>();

            services.AddTransient<IRequestReadRepository, RequestReadRepository>();
            services.AddTransient<IRequestWriteRepository, RequestWriteRepository>();

            services.AddTransient<IStudentReadRepository, StudentReadRepository>();
            services.AddTransient<IStudentWriteRepository, StudentWriteRepository>();

            services.AddTransient<ITeacherReadRepository, TeacherReadRepository>();
            services.AddTransient<ITeacherWriteRepository, TeacherWriteRepository>();

            services.AddTransient<IUserReadRepository, UserReadRepository>();
            services.AddTransient<IUserWriteRepository, UserWriteRepository>();
        }
    }
}
