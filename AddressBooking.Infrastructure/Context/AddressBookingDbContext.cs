using AddressBooking.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace AddressBooking.Infrastructure.Context 
{
    public class AddressBookingDbContext : DbContext
    {
        public AddressBookingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
