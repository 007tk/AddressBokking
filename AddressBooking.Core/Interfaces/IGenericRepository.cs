using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.Core
{
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// find all entities
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<T?>> FindAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// find entity by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T?> FindByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Insert entity of type <T>.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> InsertAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Insert entities of type <T>.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> InsertAsync(IEnumerable<T> entity, CancellationToken cancellationToken);
    }
}
