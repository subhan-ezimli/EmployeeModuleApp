using Common.Core;
using EmployeeModule.Domain.Employees;

namespace EmployeeModule.Domain.Positions.DomainEvents
{
    internal class PositionChangedDomainEvent : IDomainEvent
    {
        public PositionChangedDomainEvent(Id<Employee> id, Position position)
        {
            Id = id;
            Position = position;
        }

        public Id<Employee> Id { get; }
        public Position Position { get; }
    }
}