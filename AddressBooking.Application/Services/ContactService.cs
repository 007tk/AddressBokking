using AddressBooking.Core;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.Application
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper; 
        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ContactDto?> GetContactAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _contactRepository.FindByIdAsync(id, cancellationToken);
            var contact = _mapper.Map<ContactDto>(entity);
            return contact;
        }

        public async Task<IEnumerable<ContactDto>> GetContactsAsync(CancellationToken cancellationToken)
        {
            var entities = await _contactRepository.FindAllAsync(cancellationToken);
            var contacts = _mapper.Map<List<ContactDto>>(entities);

            return contacts;
        }

        public async Task<bool> InsertContactAsync(ContactDto dto, CancellationToken cancellationToken)
        {
            if (dto == null)
                return false;
            var entity = _mapper.Map<Contact>(dto);
            var contact = await _contactRepository.InsertAsync(entity, cancellationToken);

            return true;
        }

        public async Task<bool> UpdateContactAsync(ContactDto dto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Contact>(dto);
            var contact = await _contactRepository.UpdateAsync(entity, cancellationToken);

            return contact;
        }
    }
}
