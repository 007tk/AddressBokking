using AddressBooking.Application;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBooking.MVC.Areas.Contacts.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EditContact(int id, CancellationToken cancellationToken)
        {
            var model = await _contactService.GetContactAsync(id, cancellationToken);
            return View(model);
        }
    }
}
