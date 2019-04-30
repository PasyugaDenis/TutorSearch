using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.ContactService
{
    public interface IContactReadService
    {
        Task<Contacts> GetByIdAsync(int id);
    }
}
