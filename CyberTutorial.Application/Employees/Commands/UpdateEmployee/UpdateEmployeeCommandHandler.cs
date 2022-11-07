using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ErrorOr<UpdateEmployeeResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IHashProvider hashProvider;

        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository, IHashProvider hashProvider)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
            this.hashProvider = hashProvider;
        }

        public async Task<ErrorOr<UpdateEmployeeResult>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.TargetId != request.EmployeeId)
            {
                return Errors.Employee.OperationFailed;
            }

            if (await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId) is not Employee employee)
            {
                return Errors.Employee.NotFound;
            }

            if (employee.CompanyId != request.CompanyId)
            {
                return Errors.Employee.OperationFailed;
            }   
            
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Gender = request.Gender;
            employee.DateOfBirth = request.DateOfBirth;
            employee.PhoneNumber = request.PhoneNumber;
            employee.EmailAddress = request.EmailAddress;
            
            if (request.Password != employee.Password)
            {
                employee.Password = hashProvider.ApplyHash(request.Password);
            }

            await employeeRepository.UpdateEmployeeAsync(employee);

            return mapper.Map<UpdateEmployeeResult>(employee);
        }
    }
}