using Common.Core;
using Common.Core.Validations;
namespace EmployeeModule.Domain
{
    public sealed class DateRange : ValueObject
    {
        public DateRange(DateOnly startDate, DateOnly? endDate)
        {
            StartDate = startDate;
            if(endDate is not null)
            {
                EndDate = endDate.Value.IsGreaterThan(StartDate);
            }
        }
        public DateOnly StartDate { get; }
        public DateOnly? EndDate { get; }
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return StartDate;
            yield return EndDate;
        }

    }
}
