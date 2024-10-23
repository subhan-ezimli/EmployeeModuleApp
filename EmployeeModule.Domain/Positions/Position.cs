using Common.Core;

namespace EmployeeModule.Domain.Positions
{
    public enum PositionLevel
    {
        None,
        Level1,
        Level2,
        Level3,
        Level4
    }

    //Junior .NET Developer 800-1500 Level1,12,1
    public class Position : Aggregate<Position>
    {
        public string Name { get; }

        public Position(string name, decimal min, decimal max, PositionLevel positionLevel, byte minimumWorkingMonth, Id<PositionCategory> positionCategoryId)
        {
            Name = name;
            Min = min;
            Max = max;
            PositionLevel = positionLevel;
            MinimumWorkingMonth = minimumWorkingMonth;
            PositionCategoryId = positionCategoryId;
        }

        public decimal Min { get; }
        public decimal Max { get; }
        public PositionLevel PositionLevel { get; }
        public byte MinimumWorkingMonth { get; }
        public Id<PositionCategory> PositionCategoryId { get; }

    }
}
