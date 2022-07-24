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

        public async Task<IEnumerable<ContactDto>> GetContactsAsync(CancellationToken cancellationToken)
        {
            var entities = await _contactRepository.FindAllAsync(cancellationToken);
            var contacts = _mapper.Map<List<ContactDto>>(entities);

            return contacts;
        }
    }
}
