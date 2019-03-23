using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.MessageRepository
{
    public interface IMessageWriteRepository
    {
        Task AddAsync(Message message);

        Task UpdateAsync(Message message);

        Task RemoveAsync(Message message);
    }
}
