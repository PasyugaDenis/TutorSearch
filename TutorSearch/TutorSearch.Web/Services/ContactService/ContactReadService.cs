using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.ContactRepository;

namespace TutorSearch.Web.Services.ContactService
{
    public class ContactReadService : IContactReadService
    {
        private IContactReadRepository contactReadRepository;

        public ContactReadService(
            IContactReadRepository contactReadRepository)
        {
            this.contactReadRepository = contactReadRepository;
        }

        public async Task<Contacts> GetByIdAsync(int id)
        {
            var result = await contactReadRepository.GetAsync(id);

            return result;
        }
    }
}
