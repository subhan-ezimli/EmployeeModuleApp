using Common.Core;

namespace EmployeeModule.Domain.Positions
{
    public class PositionCategory : EntityBase<PositionCategory>
    {
        public string Name { get; }
        public PositionCategory(string name)
        {
            Name = name;
        }
        private List<Position> _positions = [];
        public void AddPosition(Position position)
        {
            _positions.Add(position);
        }
    }
}
