using MyClinic.Domain.Repositories;
using MyClinic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Persistence
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MyClinicDbContext _dbContext;

        public UnitOfWork(MyClinicDbContext dbContext) => _dbContext = dbContext;

        public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
            _dbContext.SaveChangesAsync(cancellationToken);
    }
}
