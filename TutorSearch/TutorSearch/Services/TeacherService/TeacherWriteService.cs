using System.Threading.Tasks;
using TutorSearch.Models.Entities;
using TutorSearch.Repositories.TeacherRepository;

namespace TutorSearch.Services.TeacherService
{
    public class TeacherWriteService : ITeacherWriteService
    {
        private ITeacherWriteRepository teacherWriteRepository;

        public TeacherWriteService(
            ITeacherWriteRepository teacherWriteRepository)
        {
            this.teacherWriteRepository = teacherWriteRepository;
        }

        public Task AddTeacherAsync(Teacher model)
        {
            return teacherWriteRepository.AddAsync(model);
        }
    }
}
