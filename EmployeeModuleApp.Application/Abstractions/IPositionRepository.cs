using Common.Core;
using EmployeeModule.Domain.Positions;

namespace EmployeeModuleApp.Application.Abstractions
{
    public interface IPositionRepository
    {
        Position GetAsync(Id<Position> positionId);
    }
}