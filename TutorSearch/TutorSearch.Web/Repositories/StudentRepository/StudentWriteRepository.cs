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

        public Task AddAsync(Student student)
        {
            dbContext.Students.Add(student);
            return dbContext.SaveChangesAsync();
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
