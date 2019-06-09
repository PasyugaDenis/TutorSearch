using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.ContactRepository
{
    public class ContactReadRepository : IContactReadRepository
    {
        private TutorSearchContext dbContext;

        public ContactReadRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int?> GetMaxIdAsync()
        {
            var result = dbContext.Contacts.MaxAsync(m => (int?)m.Id);

            return result;
        }

        public Task<Contacts> GetAsync(int id)
        {
            var result = dbContext.Contacts.Where(m => m.Id == id)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<List<Contacts>> GetAllAsync()
        {
            var result = dbContext.Contacts.ToListAsync();
            return result;
        }
    }
}
