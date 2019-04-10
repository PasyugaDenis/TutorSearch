using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.MessageRepository
{
    public interface IMessageReadRepository
    {
        Task<Message> GetAsync(int id);

        Task<List<Message>> GetAllAsync();
    }
}
