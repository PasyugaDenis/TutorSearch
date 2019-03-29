using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Services.StudentService
{
    public interface IStudentWriteService
    {
        Task AddStudentAsync(Student model);
    }
}
