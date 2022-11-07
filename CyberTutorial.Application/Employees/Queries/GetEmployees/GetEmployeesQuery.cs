using MediatR;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<GetEmployeesResult>
    {
    }
}