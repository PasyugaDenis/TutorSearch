using System.Data.Entity;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.ContactRepository
{
    public class ContactWriteRepository : IContactWriteRepository
    {
        private TutorSearchContext dbContext;

        public ContactWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Contacts> AddAsync(Contacts contact)
        {
            var result = dbContext.Contacts.Add(contact);
            await dbContext.SaveChangesAsync();

            return result;
        }

        public Task UpdateAsync(Contacts contact)
        {
            dbContext.Entry(contact).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Contacts contact)
        {
            dbContext.Contacts.Remove(contact);
            return dbContext.SaveChangesAsync();
        }
    }
}
