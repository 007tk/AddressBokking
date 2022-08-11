using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.Application
{
    public interface IContactService
    {
        /// <summary>
        /// Get contacts.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ContactDto>> GetContactsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get contact.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactDto?> GetContactAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Insert contact.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> InsertContactAsync(ContactDto dto, CancellationToken cancellationToken);

        /// <summary>
        /// Search duplicate contact entry. 
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> SearchDuplicate(ContactDto dto, CancellationToken cancellationToken);

        /// <summary>
        /// Update contact.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> UpdateContactAsync(ContactDto dto, CancellationToken cancellationToken);

        /// <summary>
        /// Delete contact.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeleteContactAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Merge Contact.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> MergeContact(ContactDto dto, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="csvStreamReader"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> UploadContacts(StreamReader csvStreamReader, CancellationToken cancellationToken);
    }
}
