using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.StudentRepository
{
    public class StudentReadRepository : IStudentReadRepository
    {
        private TutorSearchContext dbContext;

        public StudentReadRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Student> GetAsync(int id)
        {
            var result = dbContext.Students.Where(m => m.Id == id)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<List<Student>> GetAllAsync()
        {
            var result = dbContext.Students.ToListAsync();
            return result;
        }
    }
}
