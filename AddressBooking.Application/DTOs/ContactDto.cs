using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.Application
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string Email { get; set; }
        public int ContactNumber { get; set; }
    }
}
