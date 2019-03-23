using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.TeacherRepository
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
            dbContext.Teachers.Update(teacher);
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Teacher teacher)
        {
            dbContext.Teachers.Remove(teacher);
            return dbContext.SaveChangesAsync();
        }
    }
}
