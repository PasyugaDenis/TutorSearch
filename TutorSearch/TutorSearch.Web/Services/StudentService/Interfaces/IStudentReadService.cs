using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Response;

namespace TutorSearch.Web.Services.StudentService
{
    public interface IStudentReadService
    {
        Task<Student> GetByIdAsync(int id);

        Task<StudentViewModel> ViewStudentByIdAsync(int id);
    }
}
