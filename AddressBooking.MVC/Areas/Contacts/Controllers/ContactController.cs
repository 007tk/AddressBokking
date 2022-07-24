using Microsoft.AspNetCore.Mvc;

namespace AddressBooking.MVC.Areas.Contacts.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
