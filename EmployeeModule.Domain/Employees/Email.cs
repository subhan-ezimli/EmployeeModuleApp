using Common.Core;
using Common.Core.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModule.Domain.Employees
{
    public sealed class Email:ValueObject
    {
        public string Value { get; }
        public Email(string email)
        {
            Value = email.IsValidEmail();
        }
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
