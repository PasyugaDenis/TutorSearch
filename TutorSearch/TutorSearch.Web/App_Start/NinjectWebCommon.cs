using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Configuration;
using System.Web;
using System.Web.Http;
using TutorSearch.Web;
using TutorSearch.Web.Dependency;
using TutorSearch.Web.Repositories.ChatRepository;
using TutorSearch.Web.Repositories.ContactRepository;
using TutorSearch.Web.Repositories.CourseRepository;
using TutorSearch.Web.Repositories.MessageRepository;
using TutorSearch.Web.Repositories.RequestRepository;
using TutorSearch.Web.Repositories.StudentRepository;
using TutorSearch.Web.Repositories.TeacherRepository;
using TutorSearch.Web.Repositories.UserRepository;
using TutorSearch.Web.Services.ChatService;
using TutorSearch.Web.Services.ContactService;
using TutorSearch.Web.Services.CourseService;
using TutorSearch.Web.Services.MessageService;
using TutorSearch.Web.Services.RequestService;
using TutorSearch.Web.Services.StudentService;
using TutorSearch.Web.Services.TeacherService;
using TutorSearch.Web.Services.UserService;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace TutorSearch.Web
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Bind settings
            var settings = TutorSearchConfiguration.FromWebConfig(ConfigurationManager.AppSettings);
            kernel.Bind<TutorSearchConfiguration>().ToConstant(settings);

            //Bind Services
            kernel.Bind<IChatReadService>().To<ChatReadService>();
            kernel.Bind<IChatWriteService>().To<ChatWriteService>();

            kernel.Bind<IContactReadService>().To<ContactReadService>();
            kernel.Bind<IContactWriteService>().To<ContactWriteService>();

            kernel.Bind<ICourseReadService>().To<CourseReadService>();
            kernel.Bind<ICourseWriteService>().To<CourseWriteService>();

            kernel.Bind<IMessageReadService>().To<MessageReadService>();
            kernel.Bind<IMessageWriteService>().To<MessageWriteService>();

            kernel.Bind<IRequestReadService>().To<RequestReadService>();
            kernel.Bind<IRequestWriteService>().To<RequestWriteService>();

            kernel.Bind<IStudentReadService>().To<StudentReadService>();
            kernel.Bind<IStudentWriteService>().To<StudentWriteService>();

            kernel.Bind<ITeacherReadService>().To<TeacherReadService>();
            kernel.Bind<ITeacherWriteService>().To<TeacherWriteService>();

            kernel.Bind<IUserReadService>().To<UserReadService>();
            kernel.Bind<IUserWriteService>().To<UserWriteService>();

            //Bind repositories
            kernel.Bind<IChatReadRepository>().To<ChatReadRepository>();
            kernel.Bind<IChatWriteRepository>().To<ChatWriteRepository>();

            kernel.Bind<IContactReadRepository>().To<ContactReadRepository>();
            kernel.Bind<IContactWriteRepository>().To<ContactWriteRepository>();

            kernel.Bind<ICourseReadRepository>().To<CourseReadRepository>();
            kernel.Bind<ICourseWriteRepository>().To<CourseWriteRepository>();

            kernel.Bind<IMessageReadRepository>().To<MessageReadRepository>();
            kernel.Bind<IMessageWriteRepository>().To<MessageWriteRepository>();

            kernel.Bind<IRequestReadRepository>().To<RequestReadRepository>();
            kernel.Bind<IRequestWriteRepository>().To<RequestWriteRepository>();

            kernel.Bind<IStudentReadRepository>().To<StudentReadRepository>();
            kernel.Bind<IStudentWriteRepository>().To<StudentWriteRepository>();

            kernel.Bind<ITeacherReadRepository>().To<TeacherReadRepository>();
            kernel.Bind<ITeacherWriteRepository>().To<TeacherWriteRepository>();

            kernel.Bind<IUserReadRepository>().To<UserReadRepository>();
            kernel.Bind<IUserWriteRepository>().To<UserWriteRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
        }
    }
}