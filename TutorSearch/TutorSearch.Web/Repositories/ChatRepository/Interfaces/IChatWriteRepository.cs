using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.ChatRepository
{
    public interface IChatWriteRepository
    {
        Task<Chat> AddAsync(Chat contact);

        Task UpdateAsync(Chat contact);

        Task RemoveAsync(Chat contact);
    }
}
