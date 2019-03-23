using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.MessageRepository
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
            dbContext.Messages.Update(message);
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Message message)
        {
            dbContext.Messages.Remove(message);
            return dbContext.SaveChangesAsync();
        }
    }
}
