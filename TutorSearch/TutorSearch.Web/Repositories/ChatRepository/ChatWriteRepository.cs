using System.Data.Entity;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.ChatRepository
{
    public class ChatWriteRepository : IChatWriteRepository
    {
        private TutorSearchContext dbContext;

        public ChatWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Chat> AddAsync(Chat chat)
        {
            var result = dbContext.Chats.Add(chat);
            await dbContext.SaveChangesAsync();

            return result;
        }

        public Task UpdateAsync(Chat chat)
        {
            dbContext.Entry(chat).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Chat chat)
        {
            dbContext.Chats.Remove(chat);
            return dbContext.SaveChangesAsync();
        }
    }
}
