using Common.Core;
using Common.Core.Validations;
using EmployeeModule.Domain.Employees.DomainServices;

namespace EmployeeModule.Domain.Employees
{
    public sealed class PassportNumber : ValueObject
    {
        public bool IsValidPassport(string passport, IPassportService passportService)
        {
            return passportService.IsValid(passport);
        }
        public string Passportnumber { get; }

        public PassportNumber(string passportNumber)
        {
            Passportnumber = passportNumber.IsValidRegExp("[A-Z]{2}\\d{7}");
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Passportnumber;
        }
    }
}
