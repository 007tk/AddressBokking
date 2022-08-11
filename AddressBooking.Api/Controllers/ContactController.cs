using AddressBooking.Api.Interfaces;
using AddressBooking.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

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
        public async Task<IActionResult> AddContact([FromForm] ContactDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var duplicateDetected =  await _contactService.SearchDuplicate(dto, cancellationToken);
            if(duplicateDetected)
                return Ok("Found duplicate.");

            await _contactService.InsertContactAsync(dto, cancellationToken);

            return Ok("Contact Inserted");
        }

        [HttpGet]
        [Route(nameof(DeleteContact))]
        public async Task<IActionResult> DeleteContact(int id, CancellationToken cancellationToken)
        {
            if(id > 0)
            {
                await _contactService.DeleteContactAsync(id, cancellationToken);
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        [Route(nameof(GetContact))]
        public async Task<IActionResult> GetContact(int id, CancellationToken cancellationToken)
        {
            var contact = await _contactService.GetContactAsync(id, cancellationToken);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpGet]
        [Route(nameof(GetContacts))]
        public async Task<IEnumerable<ContactDto>> GetContacts(CancellationToken cancellationToken)
        {
            var contacts = await _contactService.GetContactsAsync(cancellationToken);
            return contacts;
        }

        [HttpPost]
        [Route(nameof(MergeContact))]
        public async Task<IActionResult> MergeContact(ContactDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var results = await _contactService.MergeContact(dto, cancellationToken);
            return Ok(results);
        }

        [HttpPost]
        [Route(nameof(UpdateContact))]
        public async Task<IActionResult> UpdateContact([FromForm] ContactDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var updatedContact = await _contactService.UpdateContactAsync(dto, cancellationToken);

            return Ok(updatedContact);
        }

        [HttpPost]
        [Route(nameof(UploadContacts))]
        public async Task<IActionResult> UploadContacts(CancellationToken cancellationToken)
        {
            var attachedFile = HttpContext.Request.Form.Files["CsvDoc"];
            if (attachedFile == null)
                return new JsonResult(null);

            var csvStreamReader = new StreamReader(attachedFile.OpenReadStream());
            var uploaded = await _contactService.UploadContacts(csvStreamReader, cancellationToken);
            if(uploaded > 0)
                return Ok(uploaded);

            return BadRequest(uploaded);
        }
    }
}
