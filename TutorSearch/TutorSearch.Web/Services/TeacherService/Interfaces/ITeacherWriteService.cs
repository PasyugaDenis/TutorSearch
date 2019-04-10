using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.TeacherService
{
    public interface ITeacherWriteService
    {
        Task AddTeacherAsync(Teacher model);

        Task EditTeacherAsync(Teacher model);
    }
}
