using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Request;

namespace TutorSearch.Web.Services.TeacherService
{
    public interface ITeacherReadService
    {
        Task<Teacher> GetByIdAsync(int id);

        Task<List<Teacher>> GetListAsync(TeacherFilterRequest filter);
    }
}