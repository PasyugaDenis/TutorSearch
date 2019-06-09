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

        public async Task<Contacts> AddContactAsync()
        {
            var contact = new Contacts();

            return await contactWriteRepository.AddAsync(contact);
        }

        public async Task UpdateContactAsync(Contacts model)
        {
            await contactWriteRepository.UpdateAsync(model);
        }
    }
}
