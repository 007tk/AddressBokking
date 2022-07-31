using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.Application
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetContactsAsync(CancellationToken cancellationToken);

        Task<ContactDto?> GetContactAsync(int id, CancellationToken cancellationToken);

        Task<bool> InsertContactAsync(ContactDto dto, CancellationToken cancellationToken);

        Task<bool> UpdateContactAsync(ContactDto dto, CancellationToken cancellationToken);

        Task<bool> DeleteContactAsync(int id, CancellationToken cancellationToken);
    }
}
