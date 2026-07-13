using Homeopathy.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Domain.Interfaces.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(int id);

        Task<List<TEntity>> GetAllAsync();

        Task<bool> ExistsAsync(int id);

        Task<int> CountAsync();
    }
}
