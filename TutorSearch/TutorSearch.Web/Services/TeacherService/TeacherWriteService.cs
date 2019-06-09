using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.TeacherRepository;

namespace TutorSearch.Web.Services.TeacherService
{
    public class TeacherWriteService : ITeacherWriteService
    {
        private ITeacherWriteRepository teacherWriteRepository;

        public TeacherWriteService(
            ITeacherWriteRepository teacherWriteRepository)
        {
            this.teacherWriteRepository = teacherWriteRepository;
        }

        public async Task AddTeacherAsync(Teacher model)
        {
            await teacherWriteRepository.AddAsync(model);
        }

        public async Task UpdateTeacherAsync(Teacher model)
        {
            await teacherWriteRepository.UpdateAsync(model);
        }
    }
}
