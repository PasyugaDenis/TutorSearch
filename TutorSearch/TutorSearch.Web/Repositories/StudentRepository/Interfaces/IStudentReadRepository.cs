using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.StudentRepository
{
    public interface IStudentReadRepository
    {
        Task<Student> GetAsync(int id);

        Task<List<Student>> GetAllAsync();
    }
}
