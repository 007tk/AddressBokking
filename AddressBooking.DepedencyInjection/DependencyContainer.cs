using AddressBooking.Application;
using AddressBooking.Core;
using AddressBooking.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.DepedencyInjection
{
    public class DependencyContainer
    {
        public static void AddAddressBookingsServices(IServiceCollection services)
        {
            // [Application Layer]
            services.AddScoped<IContactService, ContactService>();
            services.AddAutoMapper(typeof(MappingProfile));

            // [Infrastructure Layer]
            services.AddScoped<IContactRepository, ContactRepository>();


        }
    }
}
