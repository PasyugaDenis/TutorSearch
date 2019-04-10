using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.ContactRepository
{
    public interface IContactWriteRepository
    {
        Task AddAsync(Contact contact);

        Task UpdateAsync(Contact contact);

        Task RemoveAsync(Contact contact);
    }
}
