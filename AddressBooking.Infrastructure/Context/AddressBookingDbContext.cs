using AddressBooking.Core;
using Microsoft.EntityFrameworkCore;

namespace AddressBooking.Infrastructure
{
    public class AddressBookingDbContext : DbContext
    {
        public AddressBookingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
