using Common.Core;
using Common.Core.Abstractions;
using EmployeeModule.Domain.Employees;
using EmployeeModule.Domain.Positions;

namespace EmployeeModuleApp.Application.Features.Positions.Change
{
    public record PositionChangeCommand(Id<Employee> EmployeeId, Id<Position> PositionId, decimal Salary) : ICommand<Guid> { }
}
