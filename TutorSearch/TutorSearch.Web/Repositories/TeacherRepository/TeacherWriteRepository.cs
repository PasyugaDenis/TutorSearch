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

        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            var result = dbContext.Teachers.Add(teacher);
            await dbContext.SaveChangesAsync();

            return result;
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
