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

        public Task AddAsync(Contact contact)
        {
            dbContext.Contacts.Add(contact);
            return dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Contact contact)
        {
            dbContext.Entry(contact).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Contact contact)
        {
            dbContext.Contacts.Remove(contact);
            return dbContext.SaveChangesAsync();
        }
    }
}
