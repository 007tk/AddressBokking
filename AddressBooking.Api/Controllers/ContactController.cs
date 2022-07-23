using AddressBooking.Api.Interfaces;
using AddressBooking.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase, IContactApi
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        [Route(nameof(AddContact))]
        public async Task<bool> AddContact(ContactDto dto, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route(nameof(GetContact))]
        public async Task<ContactDto> GetContact(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route(nameof(GetContacts))]
        public async Task<IEnumerable<ContactDto>> GetContacts(CancellationToken cancellationToken)
        {
            var contacts = await _contactService.GetContactsAsync(cancellationToken);
            return contacts;
        }

        [HttpPost]
        [Route(nameof(UpdateContact))]
        public async Task<bool> UpdateContact(ContactDto dto, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
