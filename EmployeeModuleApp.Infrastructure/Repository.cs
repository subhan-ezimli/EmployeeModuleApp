using Common.Core;
using EmployeeModuleApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModuleApp.Application.Abstractions
{
    //database, network, file,istenieln external resusrsla islemek
    //mail sending,redis/apache kafka,service bus, sms sending lib,
    //logging, validasiya
    internal abstract class Repository<T> where T : EntityBase<T>
    {
        protected readonly EmployeeDbContext _dbContext;
        protected Repository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(Id<T> modelId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == modelId, cancellationToken);
        }

        public void AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.AddAsync(entity, cancellationToken);
        }
    }
}
