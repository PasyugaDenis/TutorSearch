using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.StudentRepository
{
    public interface IStudentWriteRepository
    {
        Task AddAsync(Student student);

        Task UpdateAsync(Student student);

        Task RemoveAsync(Student student);
    }
}
