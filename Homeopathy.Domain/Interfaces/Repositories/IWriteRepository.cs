using Homeopathy.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Domain.Interfaces.Repositories
{
    public interface IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
