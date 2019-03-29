using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Services.TeacherService
{
    public interface ITeacherWriteService
    {
        Task AddTeacherAsync(Teacher model);
    }
}
