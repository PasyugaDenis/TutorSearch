using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.TeacherRepository
{
    public interface ITeacherReadRepository
    {
        Task<Teacher> GetAsync(int id);

        Task<List<Teacher>> GetAllAsync();

        Task<List<Teacher>> SearchAsync(string[] searchValues, int? searchFrom, int? searchTo, bool? isPrivate);
    }
}
