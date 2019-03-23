using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.ContactRepository
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
            dbContext.Contacts.Update(contact);
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Contact contact)
        {
            dbContext.Contacts.Remove(contact);
            return dbContext.SaveChangesAsync();
        }
    }
}
