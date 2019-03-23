using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.TeacherRepository
{
    public interface ITeacherWriteRepository
    {
        Task AddAsync(Teacher user);

        Task UpdateAsync(Teacher user);

        Task RemoveAsync(Teacher user);
    }
}
