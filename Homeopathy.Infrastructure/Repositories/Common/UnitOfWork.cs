using Homeopathy.Domain.Interfaces;
using Homeopathy.Domain.Interfaces.Repositories;
using Homeopathy.Infrastructure.Persistence;

namespace Homeopathy.Infrastructure.Repositories.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly HomeopathyDbContext _context;

    public UnitOfWork(HomeopathyDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}