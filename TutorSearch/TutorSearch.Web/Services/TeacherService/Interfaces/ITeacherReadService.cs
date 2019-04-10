using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Response;

namespace TutorSearch.Web.Services.TeacherService
{
    public interface ITeacherReadService
    {
        Task<Teacher> GetByIdAsync(int id);

        Task<TeacherViewModel> ViewTeacherByIdAsync(int id);
    }
}