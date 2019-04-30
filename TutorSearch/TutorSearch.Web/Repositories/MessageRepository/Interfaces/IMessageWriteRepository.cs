using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.MessageRepository
{
    public interface IMessageWriteRepository
    {
        Task<Message> AddAsync(Message message);

        Task UpdateAsync(Message message);

        Task RemoveAsync(Message message);
    }
}
