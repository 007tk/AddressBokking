using AddressBooking.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBooking.Api.Interfaces
{
    public interface IContactApi
    {
        Task<IEnumerable<ContactDto>> GetContacts(CancellationToken cancellationToken);

        Task<IActionResult> GetContact(int id, CancellationToken cancellationToken);

        Task<IActionResult> AddContact(ContactDto dto, CancellationToken cancellationToken);

        Task<IActionResult> UpdateContact(ContactDto dto, CancellationToken cancellationToken);
    }
}
