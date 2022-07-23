using AddressBooking.Application;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBooking.Api.Interfaces
{
    public interface IContactApi
    {
        Task<IEnumerable<ContactDto>> GetContacts(CancellationToken cancellationToken);

        Task<ContactDto> GetContact(int id, CancellationToken cancellationToken);

        Task<bool> AddContact(ContactDto dto, CancellationToken cancellationToken);

        Task<bool> UpdateContact(ContactDto dto, CancellationToken cancellationToken);
    }
}
