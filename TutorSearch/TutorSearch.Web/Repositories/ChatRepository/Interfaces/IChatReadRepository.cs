using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.ChatRepository
{
    public interface IChatReadRepository
    {
        Task<Chat> GetAsync(int id);

        Task<List<Chat>> GetAllAsync();
    }
}
