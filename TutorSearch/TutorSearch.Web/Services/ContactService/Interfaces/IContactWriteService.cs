using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.ContactService
{
    public interface IContactWriteService
    {
        Task<Contacts> AddContactAsync();

        Task UpdateContactAsync(Contacts model);
    }
}
