using Common.Core.Abstractions;
using CSharpFunctionalExtensions;
using EmployeeModule.Domain.Employees;
using EmployeeModule.Domain.Positions;
using EmployeeModuleApp.Application.Abstractions;

namespace EmployeeModuleApp.Application.Features.Positions.Change
{
    public class PositionChangedCommandHandler : ICommandHandler<PositionChangeCommand, Guid>
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PositionChangedCommandHandler(IEmployeeRepository employeeRepository
            , IPositionRepository positionRepository
            , IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(PositionChangeCommand request, CancellationToken cancellationToken)
        {
            //Transactional operations,
            
            Employee employee = await _employeeRepository.GetAsync(request.EmployeeId);
            Position position = _positionRepository.GetAsync(request.PositionId);

            employee.ChangePosition(position);
            await _employeeRepository.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success(employee.Id.Value);
        }
    }
}
