using Common.Core;
using Common.Core.Validations;

namespace EmployeeModule.Domain.Employees
{
    public sealed class FinCode(string finCode) : ValueObject
    {
        /// <summary>
        /// dinamik almaq
        /// </summary>
        public string Fincode { get; } = finCode.IsValidRegExp("\\d{1}[A-Z]{6}");

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Fincode;
        }
    }
}
