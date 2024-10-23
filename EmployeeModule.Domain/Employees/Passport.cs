using Common.Core;
using Common.Core.Validations;
using EmployeeModule.Domain.Employees.DomainServices;

namespace EmployeeModule.Domain.Employees
{
    /*
     * CQRS, repository, unitofwork,factory m/p, entity,valuobject,aggregateroot,
     * template method pattern,strategy,command, chain of responsibility
     * */
    public sealed class Passport : ValueObject
    {
        public FinCode FinCode { get; }

        private Passport(FinCode finCode, PassportNumber passportNumber, string issueOrganization, DateRange period)
        {
            FinCode = finCode;
            PassportNumber = passportNumber;
            IssueOrganization = issueOrganization;
            Period = period;
        }

        public PassportNumber PassportNumber { get; }
        public string IssueOrganization { get; }
        public DateRange Period { get; }
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return FinCode;
            yield return PassportNumber;
            yield return IssueOrganization;
            yield return Period;
        }

        public static Passport Create(FinCode finCode, PassportNumber passportNumber, string issueOrganization, DateRange period, IPassportService passportService)
        {
            if (passportService.IsValid(passportNumber.Passportnumber))
                return new Passport(finCode, passportNumber, issueOrganization, period);
            else
                throw new ValidationException("Not possible to create Passport. Please provide a valid passport number");
        }
    }
}
