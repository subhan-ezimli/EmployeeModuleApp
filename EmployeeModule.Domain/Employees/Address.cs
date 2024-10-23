using Common.Core;
using Common.Core.Validations;

namespace EmployeeModule.Domain.Employees
{
    public sealed class Address: ValueObject
    {
        public Address(string city, string street, string postalCode)
        {
            City = city.IsNotBlank();
            Street = street.IsNotBlank();
            PostalCode = postalCode.IsValidRegExp("AZ\\d{4}");
            AddressLine = $"{city}, {street}, {postalCode}";
        }
        public string City { get; }
        public string Street { get; }
        public string PostalCode { get; }
        public string AddressLine { get; }
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
            yield return PostalCode;
            yield return AddressLine;
        }

    }
}
