using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.StudentService
{
    public interface IStudentWriteService
    {
        Task AddStudentAsync(Student model);
    }
}
