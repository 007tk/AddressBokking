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
        /// <summary>
        /// Get contacts.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ContactDto>> GetContacts(CancellationToken cancellationToken);

        /// <summary>
        /// Get contact.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IActionResult> GetContact(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Add contact.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IActionResult> AddContact(ContactDto dto, CancellationToken cancellationToken);

        /// <summary>
        /// Update contact.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IActionResult> UpdateContact(ContactDto dto, CancellationToken cancellationToken);

        /// <summary>
        /// Delete contact.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IActionResult> DeleteContact(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Merge contact.
        /// </summary>
        /// <param name=""></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IActionResult> MergeContact(ContactDto dto, CancellationToken cancellationToken);
    }
}
