using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.RequestRepository;

namespace TutorSearch.Web.Services.RequestService
{
    public class RequestWriteService : IRequestWriteService
    {
        private IRequestReadRepository requestReadRepository;
        private IRequestWriteRepository requestWriteRepository;

        public RequestWriteService(
            IRequestReadRepository requestReadRepository,
            IRequestWriteRepository requestWriteRepository)
        {
            this.requestReadRepository = requestReadRepository;
            this.requestWriteRepository = requestWriteRepository;
        }

        public async Task<Request> AddRequestAsync(Request model)
        {
            var result = await requestWriteRepository.AddAsync(model);

            return result;
        }

        public async Task AcceptAsync(int id)
        {
            var request = await requestReadRepository.GetAsync(id);

            request.IsConfirmed = true;

            await requestWriteRepository.UpdateAsync(request);
        }

        public async Task RejectAsync(int id)
        {
            var request = await requestReadRepository.GetAsync(id);

            request.IsConfirmed = false;

            await requestWriteRepository.UpdateAsync(request);
        }

        public async Task UpdateRequestAsync(Request model)
        {
            await requestWriteRepository.UpdateAsync(model);
        }
    }
}
