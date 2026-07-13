using Homeopathy.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity> where TEntity : BaseEntity
    {
    }
}
