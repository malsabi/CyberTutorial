using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Queries.GetEmployeeCompany
{
    public class GetEmployeeCompanyQuery : IRequest<ErrorOr<GetEmployeeCompanyResult>>
    {
        public string EmployeeId { get; set; }
    }
}