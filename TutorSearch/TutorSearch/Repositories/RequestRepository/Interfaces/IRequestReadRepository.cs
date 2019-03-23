using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.RequestRepository
{
    public interface IRequestReadRepository
    {
        Task<Request> GetAsync(int id);

        Task<List<Request>> GetAllAsync();
    }
}
