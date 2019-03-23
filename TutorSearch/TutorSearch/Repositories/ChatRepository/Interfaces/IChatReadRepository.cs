using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.ChatRepository
{
    public interface IChatReadRepository
    {
        Task<Chat> GetAsync(int id);

        Task<List<Chat>> GetAllAsync();
    }
}
