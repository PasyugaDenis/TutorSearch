using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.TeacherRepository
{
    public interface ITeacherWriteRepository
    {
        Task AddAsync(Teacher user);

        Task UpdateAsync(Teacher user);

        Task RemoveAsync(Teacher user);
    }
}
