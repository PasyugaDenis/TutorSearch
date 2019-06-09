using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.TeacherRepository
{
    public class TeacherReadRepository : ITeacherReadRepository
    {
        private TutorSearchContext dbContext;

        public TeacherReadRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Teacher> GetAsync(int id)
        {
            var result = dbContext.Teachers.Where(m => m.Id == id)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<List<Teacher>> GetAllAsync()
        {
            var result = dbContext.Teachers.ToListAsync();
            return result;
        }

        public Task<List<Teacher>> SearchAsync(string[] searchValues, int? searchFrom, int? searchTo, bool? isPrivate)
        {
            IQueryable<Teacher> result = dbContext.Teachers.AsQueryable();

            if (searchValues?.Length > 0)
            {
                result = result.Where(m =>
                    searchValues.Contains(m.Id.ToString()) ||
                    searchValues.Contains(m.Education) ||
                    searchValues.Contains(m.Skill) ||
                    searchValues.Contains(m.City) ||
                    searchValues.Contains(m.User.Name) ||
                    searchValues.Contains(m.User.Surname) ||
                    searchValues.Contains(m.User.Email) ||
                    searchValues.Contains(m.User.Phone));
            }

            if (searchFrom.HasValue && searchTo.HasValue)
            {
                result = result.Where(m => 
                    m.WorkExperience >= searchFrom &&
                    m.WorkExperience <= searchTo);
            }

            if (isPrivate.HasValue)
            {
                result = result.Where(m => m.IsPrivate == isPrivate);
            }

            return result.ToListAsync();
        }

    }
}
