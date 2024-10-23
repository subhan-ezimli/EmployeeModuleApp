using Common.Core;
using EmployeeModule.Domain.Employees;

namespace EmployeeModuleApp.Application.Abstractions
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetAsync(Id<Employee> employeeId);
        Task UpdateAsync(Employee employee);
    }
}