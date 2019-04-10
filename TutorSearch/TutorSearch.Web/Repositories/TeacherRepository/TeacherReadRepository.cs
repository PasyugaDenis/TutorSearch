using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.TeacherRepository
{
    public class TeacherReadRepository : ITeacherReadRepository
    {
        private TutorSearchContext dbContext;

        public TeacherReadRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Teacher> GetAsync(int id)
        {
            var result = dbContext.Teachers.Where(m => m.Id == id)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<List<Teacher>> GetAllAsync()
        {
            var result = dbContext.Teachers.ToListAsync();
            return result;
        }
    }
}
