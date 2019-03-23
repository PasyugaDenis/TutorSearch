using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.TeacherRepository
{
    public interface ITeacherReadRepository
    {
        Task<Teacher> GetAsync(int id);

        Task<List<Teacher>> GetAllAsync();
    }
}
