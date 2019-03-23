using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.RequestRepository
{
    public interface IRequestWriteRepository
    {
        Task AddAsync(Request student);

        Task UpdateAsync(Request student);

        Task RemoveAsync(Request student);
    }
}
