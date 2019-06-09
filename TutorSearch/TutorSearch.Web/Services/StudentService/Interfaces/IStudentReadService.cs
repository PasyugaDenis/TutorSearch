using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.StudentService
{
    public interface IStudentReadService
    {
        Task<Student> GetStudentAsync(int id);
    }
}
