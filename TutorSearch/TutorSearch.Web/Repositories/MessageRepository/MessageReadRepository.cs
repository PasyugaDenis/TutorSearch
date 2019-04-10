using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.MessageRepository
{
    public class MessageReadRepository : IMessageReadRepository
    {
        private TutorSearchContext dbContext;

        public MessageReadRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Message> GetAsync(int id)
        {
            var result = dbContext.Messages.Where(m => m.Id == id)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<List<Message>> GetAllAsync()
        {
            var result = dbContext.Messages.ToListAsync();
            return result;
        }
    }
}
