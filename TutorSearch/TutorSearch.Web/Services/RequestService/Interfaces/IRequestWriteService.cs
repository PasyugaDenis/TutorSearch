using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.RequestService
{
    public interface IRequestWriteService
    {
        Task<Request> AddRequestAsync(Request model);

        Task AcceptAsync(int id);

        Task RejectAsync(int id);

        Task UpdateRequestAsync(Request model);
        Task DeleteRequestAsync(Request request);
    }
}
