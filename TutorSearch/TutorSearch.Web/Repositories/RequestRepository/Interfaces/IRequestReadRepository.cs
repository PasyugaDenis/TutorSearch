using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.RequestRepository
{
    public interface IRequestReadRepository
    {
        Task<Request> GetAsync(int id);

        Task<List<Request>> GetAllAsync();

        Task<List<Request>> GetByCourseIdAsync(int courseId);

        Task<List<Request>> GetByTeacherIdAsync(int courseId);

        Task<List<Request>> GetByStudentIdAsync(int courseId);
    }
}
