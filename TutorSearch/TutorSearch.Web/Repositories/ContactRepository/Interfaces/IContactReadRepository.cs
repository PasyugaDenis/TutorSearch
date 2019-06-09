using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.ContactRepository
{
    public interface IContactReadRepository
    {
        Task<int?> GetMaxIdAsync();

        Task<Contacts> GetAsync(int id);

        Task<List<Contacts>> GetAllAsync();
    }
}
