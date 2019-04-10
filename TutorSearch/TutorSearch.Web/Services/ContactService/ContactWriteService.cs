using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.ContactRepository;

namespace TutorSearch.Web.Services.ContactService
{
    public class ContactWriteService : IContactWriteService
    {
        private IContactWriteRepository contactWriteRepository;
        private IContactReadRepository contactReadRepository;

        public ContactWriteService(
            IContactWriteRepository contactWriteRepository,
            IContactReadRepository contactReadRepository)
        {
            this.contactWriteRepository = contactWriteRepository;
            this.contactReadRepository = contactReadRepository;
        }

        public async Task<Contact> AddContactAsync()
        {
            var maxId = await contactReadRepository.GetMaxIdAsync() ?? 0;

            var contact = new Contact
            {
                Id = ++maxId
            };

            await contactWriteRepository.AddAsync(contact);

            return contact;
        }
    }
}
