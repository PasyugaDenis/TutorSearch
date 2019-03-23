using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.ChatRepository
{
    public interface IChatWriteRepository
    {
        Task AddAsync(Chat contact);

        Task UpdateAsync(Chat contact);

        Task RemoveAsync(Chat contact);
    }
}
