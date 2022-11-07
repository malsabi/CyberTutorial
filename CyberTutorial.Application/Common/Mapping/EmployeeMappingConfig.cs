using Mapster;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Common.Mapping
{
    public class EmployeeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //GetEmployeeById
            config.NewConfig<Employee, GetEmployeeByIdResult>()
                  .Map(dest => dest.Employee.CompanyId, src => src.CompanyId)
                  .Map(dest => dest.Employee.EmployeeId, src => src.EmployeeId)
                  .Map(dest => dest.Employee.FirstName, src => src.FirstName)
                  .Map(dest => dest.Employee.LastName, src => src.LastName)
                  .Map(dest => dest.Employee.Gender, src => src.Gender)
                  .Map(dest => dest.Employee.DateOfBirth, src => src.DateOfBirth)
                  .Map(dest => dest.Employee.PhoneNumber, src => src.PhoneNumber)
                  .Map(dest => dest.Employee.EmailAddress, src => src.EmailAddress)
                  .Map(dest => dest.Employee.Password, src => src.Password)
                  .Map(dest => dest.Employee.Company, src => src.Company)
                  .Map(dest => dest.Employee.TopEmployee, src => src.TopEmployee)
                  .Map(dest => dest.Employee.EmployeeDashboard, src => src.EmployeeDashboard)
                  .Map(dest => dest.Employee.Courses, src => src.Courses)
                  .Map(dest => dest.Employee.Attempts, src => src.Attempts)
                  .Map(dest => dest.Employee.Session, src => src.Session)
                  .MaxDepth(4);

            //GetEmployeeSession
            config.NewConfig<EmployeeSession, GetEmployeeSessionResult>()
                  .Map(dest => dest.Session.EmployeeSessionId, src => src.EmployeeSessionId)
                  .Map(dest => dest.Session.TimeCreated, src => src.TimeCreated)
                  .Map(dest => dest.Session.ExpiryDate, src => src.ExpiryDate)
                  .Map(dest => dest.Session.Token, src => src.Token)
                  .Map(dest => dest.Session.IsActive, src => src.IsActive);

            //GetEmployeeCompany
            config.NewConfig<Company, GetEmployeeCompanyResult>()
                  .Map(dest => dest.Company.CompanyId, src => src.CompanyId)
                  .Map(dest => dest.Company.CompanyName, src => src.CompanyName)
                  .Map(dest => dest.Company.OwnerFirstName, src => src.OwnerFirstName)
                  .Map(dest => dest.Company.OwnerLastName, src => src.OwnerLastName)
                  .Map(dest => dest.Company.OwnerEmiratesId, src => src.OwnerEmiratesId)
                  .Map(dest => dest.Company.PhoneNumber, src => src.PhoneNumber)
                  .Map(dest => dest.Company.EmailAddress, src => src.EmailAddress)
                  .Map(dest => dest.Company.State, src => src.State)
                  .Map(dest => dest.Company.Region, src => src.Region)
                  .Map(dest => dest.Company.StreetAddress, src => src.StreetAddress)
                  .Map(dest => dest.Company.Website, src => src.Website)
                  .Map(dest => dest.Company.CompanyDescription, src => src.CompanyDescription)
                  .Map(dest => dest.Company.Password, src => src.Password)
                  .Map(dest => dest.Company.Employees, src => src.Employees)
                  .Map(dest => dest.Company.Session, src => src.Session)
                  .MaxDepth(4);

            //GetEmployeeDashboardById
            config.NewConfig<EmployeeDashboard, GetEmployeeDashboardResult>()
                  .Map(dest => dest.EmployeeDashboard.EmployeeDashboardId, src => src.EmployeeDashboardId)
                  .Map(dest => dest.EmployeeDashboard.TotalCourses, src => src.TotalCourses)
                  .Map(dest => dest.EmployeeDashboard.TotalCoursesLastModified, src => src.TotalCoursesLastModified)
                  .Map(dest => dest.EmployeeDashboard.TotalQuizzes, src => src.TotalQuizzes)
                  .Map(dest => dest.EmployeeDashboard.TotalQuizzesLastModified, src => src.TotalQuizzesLastModified)
                  .Map(dest => dest.EmployeeDashboard.TotalPassed, src => src.TotalPassed)
                  .Map(dest => dest.EmployeeDashboard.TotalPassedLastModified, src => src.TotalPassedLastModified)
                  .Map(dest => dest.EmployeeDashboard.TotalFailed, src => src.TotalFailed)
                  .Map(dest => dest.EmployeeDashboard.TotalFailedLastModified, src => src.TotalFailedLastModified);

            //UpdateEmployee
            config.NewConfig<Employee, UpdateEmployeeResult>()
                  .Map(dest => dest.Employee.CompanyId, src => src.CompanyId) 
                  .Map(dest => dest.Employee.EmployeeId, src => src.EmployeeId)
                  .Map(dest => dest.Employee.FirstName, src => src.FirstName)
                  .Map(dest => dest.Employee.LastName, src => src.LastName)
                  .Map(dest => dest.Employee.Gender, src => src.Gender)
                  .Map(dest => dest.Employee.DateOfBirth, src => src.DateOfBirth)
                  .Map(dest => dest.Employee.PhoneNumber, src => src.PhoneNumber)
                  .Map(dest => dest.Employee.EmailAddress, src => src.EmailAddress)
                  .Map(dest => dest.Employee.Password, src => src.Password)
                  .Map(dest => dest.Employee.Company, src => src.Company)
                  .Map(dest => dest.Employee.TopEmployee, src => src.TopEmployee)
                  .Map(dest => dest.Employee.EmployeeDashboard, src => src.EmployeeDashboard)
                  .Map(dest => dest.Employee.Courses, src => src.Courses)
                  .Map(dest => dest.Employee.Attempts, src => src.Attempts)
                  .Map(dest => dest.Employee.Session, src => src.Session)
                  .MaxDepth(4);

            //UpdateEmployeeDashboard
            config.NewConfig<EmployeeDashboard, UpdateEmployeeDashboardResult>()
                  .Map(dest => dest.EmployeeDashboard.EmployeeDashboardId, src => src.EmployeeDashboardId)
                  .Map(dest => dest.EmployeeDashboard.TotalCourses, src => src.TotalCourses)
                  .Map(dest => dest.EmployeeDashboard.TotalCoursesLastModified, src => src.TotalCoursesLastModified)
                  .Map(dest => dest.EmployeeDashboard.TotalQuizzes, src => src.TotalQuizzes)
                  .Map(dest => dest.EmployeeDashboard.TotalQuizzesLastModified, src => src.TotalQuizzesLastModified)
                  .Map(dest => dest.EmployeeDashboard.TotalPassed, src => src.TotalPassed)
                  .Map(dest => dest.EmployeeDashboard.TotalPassedLastModified, src => src.TotalPassedLastModified)
                  .Map(dest => dest.EmployeeDashboard.TotalFailed, src => src.TotalFailed)
                  .Map(dest => dest.EmployeeDashboard.TotalFailedLastModified, src => src.TotalFailedLastModified);

            //UpdateEmployeeSession
            config.NewConfig<EmployeeSession, UpdateEmployeeSessionResult>()
                 .Map(dest => dest.Session.EmployeeSessionId, src => src.EmployeeSessionId)
                 .Map(dest => dest.Session.TimeCreated, src => src.TimeCreated)
                 .Map(dest => dest.Session.ExpiryDate, src => src.ExpiryDate)
                 .Map(dest => dest.Session.Token, src => src.Token)
                 .Map(dest => dest.Session.IsActive, src => src.IsActive);
        }
    }
}