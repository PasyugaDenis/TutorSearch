using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.ContactRepository
{
    public interface IContactWriteRepository
    {
        Task AddAsync(Contact contact);

        Task UpdateAsync(Contact contact);

        Task RemoveAsync(Contact contact);
    }
}
