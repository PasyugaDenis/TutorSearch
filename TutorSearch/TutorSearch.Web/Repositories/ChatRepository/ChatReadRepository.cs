using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.ChatRepository
{
    public class ChatReadRepository : IChatReadRepository
    {
        private TutorSearchContext dbContext;

        public ChatReadRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Chat> GetAsync(int id)
        {
            var result = dbContext.Chats.Where(m => m.Id == id)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<List<Chat>> GetAllAsync()
        {
            var result = dbContext.Chats.ToListAsync();
            return result;
        }
    }
}
