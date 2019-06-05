using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Request;
using TutorSearch.Web.Models.Response;
using TutorSearch.Web.Repositories.TeacherRepository;
using TutorSearch.Web.Repositories.UserRepository;

namespace TutorSearch.Web.Services.TeacherService
{
    public class TeacherReadService : ITeacherReadService
    {
        private ITeacherReadRepository teacherReadRepository;
        private IUserReadRepository userReadRepository;

        public TeacherReadService(
            ITeacherReadRepository teacherReadRepository,
            IUserReadRepository userReadRepository)
        {
            this.teacherReadRepository = teacherReadRepository;
            this.userReadRepository = userReadRepository;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var model = await teacherReadRepository.GetAsync(id);

            return model;
        }

        public async Task<List<Teacher>> GetListAsync(TeacherFilterRequest filter)
        {
            //filter
            var list = await teacherReadRepository.
                SearchAsync(filter.SearchValues, filter.SearchFrom, filter.SearchTo, filter.IsPrivate);

            //sort
            list = Sort(list, filter.SortField, filter.SortAscending);

            return list;
        }

        private List<Teacher> Sort(List<Teacher> list, string sortField, bool sortAscending)
        {
            IOrderedEnumerable<Teacher> result;

            switch (sortField?.ToLower())
            {
                case "name":
                    result = sortAscending
                        ? list.OrderBy(m => m.User.Name)
                        : list.OrderByDescending(m => m.User.Name);
                    break;
                case "surname":
                    result = sortAscending
                        ? list.OrderBy(m => m.User.Surname)
                        : list.OrderByDescending(m => m.User.Surname);
                    break;
                case "birthday":
                    result = sortAscending
                        ? list.OrderBy(m => m.User.Birthday)
                        : list.OrderByDescending(m => m.User.Birthday);
                    break;
                case "email":
                    result = sortAscending
                        ? list.OrderBy(m => m.User.Email)
                        : list.OrderByDescending(m => m.User.Email);
                    break;
                case "phone":
                    result = sortAscending
                        ? list.OrderBy(m => m.User.Phone)
                        : list.OrderByDescending(m => m.User.Phone);
                    break;
                case "education":
                    result = sortAscending
                        ? list.OrderBy(m => m.Education)
                        : list.OrderByDescending(m => m.Education);
                    break;
                case "skill":
                    result = sortAscending
                        ? list.OrderBy(m => m.Skill)
                        : list.OrderByDescending(m => m.Skill);
                    break;
                case "city":
                    result = sortAscending
                        ? list.OrderBy(m => m.City)
                        : list.OrderByDescending(m => m.City);
                    break;
                case "workexperience":
                    result = sortAscending
                        ? list.OrderBy(m => m.WorkExperience)
                        : list.OrderByDescending(m => m.WorkExperience);
                    break;
                case "id":
                default:
                    result = sortAscending
                        ? list.OrderBy(m => m.Id)
                        : list.OrderByDescending(m => m.Id);
                    break;
            }

            return result.ToList();
        }
    }
}