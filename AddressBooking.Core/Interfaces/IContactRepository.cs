﻿using AddressBooking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.Core
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        public IQueryable<Contact> Query { get; }
    }
}
