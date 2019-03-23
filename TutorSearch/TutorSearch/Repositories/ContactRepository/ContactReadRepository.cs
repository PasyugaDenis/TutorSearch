using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.ContactRepository
{
    public class ContactReadRepository : IContactReadRepository
    {
        private TutorSearchContext dbContext;

        public ContactReadRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Contact> GetAsync(int id)
        {
            var result = dbContext.Contacts.Where(m => m.Id == id)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<List<Contact>> GetAllAsync()
        {
            var result = dbContext.Contacts.ToListAsync();
            return result;
        }
    }
}
