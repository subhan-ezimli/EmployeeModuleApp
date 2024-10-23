using Common.Core;
using EmployeeModule.Domain.Employees;
using EmployeeModuleApp.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeModuleApp.Infrastructure
{
    public class EmployeeDbContext : DbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;
        public DbSet<Employee> Employees { get; set; }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContextOptions,IPublisher publisher) : base(dbContextOptions)
        {
            _publisher = publisher;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var saveResult = await base.SaveChangesAsync(cancellationToken);
            await PublishEventsAsync();
            return saveResult;
        }

        private async Task PublishEventsAsync()
        {
           var domainEvents = ChangeTracker.Entries<Aggregate<IAuditableModel>>()
                 .Select(x => x.Entity)
                 .SelectMany(entity =>
                 {
                     var domainEvents = entity.GetDomainEvents();
                     entity.ClearDomainEvents();
                     return domainEvents;
                 }).ToList();

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
        }
    }
}
