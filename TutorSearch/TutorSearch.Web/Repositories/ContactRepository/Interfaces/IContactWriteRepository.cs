using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.ContactRepository
{
    public interface IContactWriteRepository
    {
        Task<Contacts> AddAsync(Contacts contact);

        Task UpdateAsync(Contacts contact);

        Task RemoveAsync(Contacts contact);
    }
}
