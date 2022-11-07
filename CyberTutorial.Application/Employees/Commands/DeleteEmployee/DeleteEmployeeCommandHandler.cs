using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ErrorOr<DeleteEmployeeResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public DeleteEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }
        
        public async Task<ErrorOr<DeleteEmployeeResult>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

            if (employee is null)
            {
                return Errors.Company.NotFound;
            }

            await employeeRepository.DeleteEmployeeAsync(request.EmployeeId);

            return mapper.Map<DeleteEmployeeResult>(employee);
        }
    }
}