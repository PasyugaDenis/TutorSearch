using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.StudentRepository
{
    public interface IStudentReadRepository
    {
        Task<Student> GetAsync(int id);

        Task<List<Student>> GetAllAsync();
    }
}
