using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.RequestRepository;

namespace TutorSearch.Web.Services.RequestService
{
    public class RequestReadService : IRequestReadService
    {
        private IRequestReadRepository requestReadRepository;

        public RequestReadService(IRequestReadRepository requestReadRepository)
        {
            this.requestReadRepository = requestReadRepository;
        }

        public async Task<Request> GetRequestAsync(int id)
        {
            var course = await requestReadRepository.GetAsync(id);

            return course;
        }

        public async Task<List<Request>> GetRequestsByCourseIdAsync(int courseId)
        {
            var course = await requestReadRepository.GetByCourseIdAsync(courseId);

            return course;
        }
    }
}
