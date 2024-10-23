using Common.Core;
using Common.Core.Validations;
using EmployeeModule.Domain.Employees.DomainEvents;
using EmployeeModule.Domain.Positions;
using EmployeeModule.Domain.Positions.DomainEvents;
using EmployeeModule.Domain.Warehouses;

namespace EmployeeModule.Domain.Employees
{
    public sealed class Employee : Aggregate<Employee>
    {
        public FullName FullName { get; }
        private Employee(FullName fullName
            , Address address
            , Passport passport
            , DateRange period
            , Email email
            , string phoneNumber
            , Id<Warehouse> warehouseId
            , Position position
            , Guid? id) : base(id ?? Guid.NewGuid())
        {
            FullName = fullName;
            Address = address;
            Passport = passport;
            Period = period;
            Email = email;
            PhoneNumber = phoneNumber;
            WarehouseId = warehouseId;
            Position = position;
        }

        public Address Address { get; }
        public Passport Passport { get; }
        public DateRange Period { get; }
        public Email Email { get; }
        public string PhoneNumber { get; }
        public Id<Warehouse> WarehouseId { get; }
        public Position Position { get; private set; }
        public static Employee Create(FullName fullName
            , Address address
            , Passport passport
            , DateRange period
            , Email email
            , string phoneNumber
            , Id<Warehouse> warehouseId
            , Position position
            , Guid? id)
        {
            var employee = new Employee(fullName, address, passport, period, email, phoneNumber, warehouseId, position, id);
            employee.RaiseDomainEvent(new EmployeeCreatedDomainEvent(employee.Id));
            return employee;
        }

        public void ChangePosition(Position newPosition)
        {
            if (!IsEligibleForPositionChange())
                throw new ValidationException("Employee is not eligible for a position change.");

            if (!IsPositionChangeAllowed(newPosition))
                throw new ValidationException("Position change is not allowed between provided positions.");

            Position = newPosition;
            RaiseDomainEvent(new PositionChangedDomainEvent(Id, Position));
        }

        //TAM olaraq biznese aidiyyati olan funksionalliqlar
        private bool IsEligibleForPositionChange()
        {
            var monthsWorked = DateTime.UtcNow.Subtract(Period.StartDate.ToDateTime(TimeOnly.MinValue)).TotalDays / 30;
            return monthsWorked >= Position.MinimumWorkingMonth;
        }

        private bool IsPositionChangeAllowed(Position newPosition)
        {
            if (Position.PositionLevel == PositionLevel.None || Position.PositionLevel == PositionLevel.Level4)
                return true;

            return ((int)Position.PositionLevel) + 1 == (int)newPosition.PositionLevel;
        }
    }
}
