using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.ContactRepository
{
    public interface IContactReadRepository
    {
        Task<Contact> GetAsync(int id);

        Task<List<Contact>> GetAllAsync();
    }
}
