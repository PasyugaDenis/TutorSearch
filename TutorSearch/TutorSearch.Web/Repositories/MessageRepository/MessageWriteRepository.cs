using System.Data.Entity;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.MessageRepository
{
    public class MessageWriteRepository : IMessageWriteRepository
    {
        private TutorSearchContext dbContext;

        public MessageWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddAsync(Message message)
        {
            dbContext.Messages.Add(message);
            return dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Message message)
        {
            dbContext.Entry(message).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Message message)
        {
            dbContext.Messages.Remove(message);
            return dbContext.SaveChangesAsync();
        }
    }
}
