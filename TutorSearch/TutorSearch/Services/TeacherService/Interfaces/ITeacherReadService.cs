using System.Threading.Tasks;
using TutorSearch.Models.Response;

namespace TutorSearch.Services.TeacherService
{
    public interface ITeacherReadService
    {
        Task<TeacherViewModel> ViewTeacherByIdAsync(int id);
    }
}
