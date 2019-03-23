using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.ChatRepository
{
    public class ChatWriteRepository : IChatWriteRepository
    {
        private TutorSearchContext dbContext;

        public ChatWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddAsync(Chat chat)
        {
            dbContext.Chats.Add(chat);
            return dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Chat chat)
        {
            dbContext.Chats.Update(chat);
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Chat chat)
        {
            dbContext.Chats.Remove(chat);
            return dbContext.SaveChangesAsync();
        }
    }
}
