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

        public async Task<bool> DeleteContactAsync(int id, CancellationToken cancellationToken)
        {
            var entity = id > 0 ? await _contactRepository.FindByIdAsync(id, cancellationToken) : null;
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _contactRepository.UpdateAsync(entity, cancellationToken);
                return true;
            }

            return false;
        }

        public async Task<ContactDto?> GetContactAsync(int id, CancellationToken cancellationToken)
        {
            var entity = id > 0 ? await _contactRepository.FindByIdAsync(id, cancellationToken) : null;

            if(entity != null)
            {
                var contact = _mapper.Map<ContactDto>(entity);
                return contact;
            }

            return null;

        }

        public async Task<IEnumerable<ContactDto>> GetContactsAsync(CancellationToken cancellationToken)
        {
            var entities = await _contactRepository.FindAllAsync(cancellationToken);
            var activeContacts = entities.Where(c => c.IsDeleted == false);
            var contacts = _mapper.Map<List<ContactDto>>(activeContacts);

            return contacts;
        }

        public async Task<bool> InsertContactAsync(ContactDto dto, CancellationToken cancellationToken)
        {
            if (dto == null)
                return false;
                
           var entity = _mapper.Map<Contact>(dto);
           await _contactRepository.InsertAsync(entity, cancellationToken);

            return true;
        }

        public async Task<bool> MergeContact(ContactDto dto, CancellationToken cancellationToken)
        {
            var contactInDb = _contactRepository.Query.Where(c => c.ContactName == dto.ContactName && c.ContactSurname == dto.ContactSurname).FirstOrDefault();
            if (contactInDb != null)
                return false;

            // Update fields
            contactInDb.ContactName = dto.ContactName;
            contactInDb.ContactSurname = dto.ContactSurname;
            contactInDb.ContactNumber = dto.ContactNumber;
            contactInDb.Address = dto.Address;
            contactInDb.DateOfBirth = dto.DateOfBirth;
            contactInDb.Age = dto.Age;

            var duplicate = _mapper.Map<Contact>(contactInDb);
            await _contactRepository.UpdateAsync(duplicate, cancellationToken);
            return true;
        }

        public async Task<bool> SearchDuplicate(ContactDto dto, CancellationToken cancellationToken)
        {
            // Search duplicate.
            var contactInDb = _contactRepository.Query.Where(c => c.ContactName == dto.ContactName && c.ContactSurname == dto.ContactSurname).FirstOrDefault();
            if (contactInDb != null)
                return true;

            return false;
        }

        public async Task<bool> UpdateContactAsync(ContactDto dto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Contact>(dto);
            var contact = await _contactRepository.UpdateAsync(entity, cancellationToken);

            return contact;
        }
    }
}
