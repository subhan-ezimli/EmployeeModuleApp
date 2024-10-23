using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModule.Domain.Employees.DomainServices
{
    public interface IPassportService
    {
        public bool IsValid(string passport);
    }
}
