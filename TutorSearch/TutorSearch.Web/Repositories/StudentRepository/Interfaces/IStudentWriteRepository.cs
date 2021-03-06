using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.StudentRepository
{
    public interface IStudentWriteRepository
    {
        Task<Student> AddAsync(Student student);

        Task UpdateAsync(Student student);

        Task RemoveAsync(Student student);
    }
}
