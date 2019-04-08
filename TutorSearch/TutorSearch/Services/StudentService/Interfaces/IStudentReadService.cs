using System.Threading.Tasks;
using TutorSearch.Models.Response;

namespace TutorSearch.Services.StudentService
{
    public interface IStudentReadService
    {
        Task<StudentViewModel> ViewStudentByIdAsync(int id);
    }
}
