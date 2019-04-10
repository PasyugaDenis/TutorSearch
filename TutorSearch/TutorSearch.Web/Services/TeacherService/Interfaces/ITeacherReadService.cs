using System.Threading.Tasks;
using TutorSearch.Web.Models.Response;

namespace TutorSearch.Web.Services.TeacherService
{
    public interface ITeacherReadService
    {
        Task<TeacherViewModel> ViewTeacherByIdAsync(int id);
    }
}