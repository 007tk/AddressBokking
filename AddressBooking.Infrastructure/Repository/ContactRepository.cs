﻿using AddressBooking.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.Infrastructure.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AddressBookingDbContext _dbContext;

        public ContactRepository(AddressBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Contact> Query
        {
            get
            {
                return _dbContext.Set<Contact>();
            }
        }

        public async Task<IEnumerable<Contact?>> FindAllAsync(CancellationToken cancellationToken)
        {
            var contacts = await _dbContext.Contacts.ToListAsync(cancellationToken);
            return contacts;
        }

        public async Task<Contact?> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == id,cancellationToken);
            return contact;
        }

        public async Task<Contact> InsertAsync(Contact entity, CancellationToken cancellationToken)
        {
            var contact = await _dbContext.Contacts.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return contact.Entity;
        }

        public async Task<int> InsertAsync(IEnumerable<Contact> entities, CancellationToken cancellationToken)
        {
            await _dbContext.Contacts.AddRangeAsync(entities, cancellationToken);
            var results = await _dbContext.SaveChangesAsync(cancellationToken);

            return results;
        }

        public async Task<bool> UpdateAsync(Contact entity, CancellationToken cancellationToken)
        {
            var entry = _dbContext.Contacts.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
                
            return true;
        }
    }
}
