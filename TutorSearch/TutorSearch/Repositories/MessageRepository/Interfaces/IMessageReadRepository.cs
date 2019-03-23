using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.MessageRepository
{
    public interface IMessageReadRepository
    {
        Task<Message> GetAsync(int id);

        Task<List<Message>> GetAllAsync();
    }
}
