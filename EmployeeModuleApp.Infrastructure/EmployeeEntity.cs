namespace EmployeeModuleApp.Infrastructure
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
    //Employee -> EmployeeEntity
    //Employee->Employee (domain model)
    public class EmployeeEntity : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public Guid WarehouseId { get; }
        public PositionEntity Position { get; }

    }
}
