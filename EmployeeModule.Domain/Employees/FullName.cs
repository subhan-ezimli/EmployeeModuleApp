using Common.Core;
using Common.Core.Validations;

namespace EmployeeModule.Domain.Employees
{
    public class FullName(string name, string surname) : ValueObject
    {
        public string Name { get; } = name.HasMinLength(3).IsAlphabetical();
        public string Surname { get; } = surname.HasMinLength(3).IsAlphabetical();
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Name;
            yield return Surname;
        }
    }
}
