using Common.Core;

namespace EmployeeModule.Domain.Employees.DomainEvents
{
    public class EmployeeCreatedDomainEvent : IDomainEvent
    {
        public Id<Employee> EmployeeId { get; }
        public EmployeeCreatedDomainEvent(Id<Employee> employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
