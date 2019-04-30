using System.Data.Entity;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.StudentRepository
{
    public class StudentWriteRepository : IStudentWriteRepository
    {
        private TutorSearchContext dbContext;

        public StudentWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Student> AddAsync(Student student)
        {
            var result = dbContext.Students.Add(student);
            await dbContext.SaveChangesAsync();

            return result;
        }

        public Task UpdateAsync(Student student)
        {
            dbContext.Entry(student).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Student student)
        {
            dbContext.Students.Remove(student);
            return dbContext.SaveChangesAsync();
        }
    }
}
