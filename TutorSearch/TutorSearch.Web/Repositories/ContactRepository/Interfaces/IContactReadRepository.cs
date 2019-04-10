using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.ContactRepository
{
    public interface IContactReadRepository
    {
        Task<int?> GetMaxIdAsync();

        Task<Contact> GetAsync(int id);

        Task<List<Contact>> GetAllAsync();
    }
}
