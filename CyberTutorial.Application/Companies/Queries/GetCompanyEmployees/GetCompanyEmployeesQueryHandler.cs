using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Companies.Queries.GetCompanyEmployees
{
    public class GetCompanyEmployeesQueryHandler : IRequestHandler<GetCompanyEmployeesQuery, ErrorOr<GetCompanyEmployeesResult>>
    {
        private readonly ICompanyRepository companyRepository;

        public GetCompanyEmployeesQueryHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<ErrorOr<GetCompanyEmployeesResult>> Handle(GetCompanyEmployeesQuery request, CancellationToken cancellationToken)
        {
            if (await companyRepository.GetCompanyByIdAsync(request.CompanyId) is not Company company)
            {
                return Errors.Company.NotFound;
            }

            ICollection<Employee> employees = company.Employees;

            if (employees == null || employees.Count == 0)
            {
                return Errors.Company.NoEmployeesFound;
            }

            return new GetCompanyEmployeesResult()
            {
                Employees = employees
            };
        }
    }
}