using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.RequestRepository
{
    public interface IRequestWriteRepository
    {
        Task<Request> AddAsync(Request student);

        Task UpdateAsync(Request student);

        Task RemoveAsync(Request student);
    }
}
