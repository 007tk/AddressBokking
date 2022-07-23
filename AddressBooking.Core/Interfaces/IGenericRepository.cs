using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.Core
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> FindAllAsync(CancellationToken cancellationToken);

        Task<T> FindByIdAsync(int id, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
