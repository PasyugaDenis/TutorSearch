using System.Data.Entity;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.TeacherRepository
{
    public class TeacherWriteRepository : ITeacherWriteRepository
    {
        private TutorSearchContext dbContext;

        public TeacherWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddAsync(Teacher teacher)
        {
            dbContext.Teachers.Add(teacher);
            return dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Teacher teacher)
        {
            dbContext.Entry(teacher).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Teacher teacher)
        {
            dbContext.Teachers.Remove(teacher);
            return dbContext.SaveChangesAsync();
        }
    }
}
