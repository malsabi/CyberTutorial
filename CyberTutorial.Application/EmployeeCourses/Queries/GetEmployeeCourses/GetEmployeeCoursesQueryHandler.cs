using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.EmployeeCourses.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.EmployeeCourses.Queries.GetEmployeeCourses
{
    public class GetEmployeeCoursesQueryHandler : IRequestHandler<GetEmployeeCoursesQuery, ErrorOr<GetEmployeeCoursesResult>>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICourseRepository courseRepository;

        public GetEmployeeCoursesQueryHandler(IEmployeeRepository employeeRepository, ICourseRepository courseRepository)
        {
            this.employeeRepository = employeeRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<GetEmployeeCoursesResult>> Handle(GetEmployeeCoursesQuery request, CancellationToken cancellationToken)
        {
            if (await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId) is not Employee employee)
            {
                return Errors.Employee.NotFound;
            }

            ICollection<Course> existingCourses = await courseRepository.GetCoursesAsync();
            
            if (!existingCourses.Any(ec => ec.Employees.Any(e => e.EmployeeId == request.EmployeeId)))
            {
                return Errors.EmployeeCourse.NotRegisteredInAllCourses;
            }

            ICollection<Course> courses = employee.Courses;

            if (courses == null || courses.Count == 0)
            {
                return Errors.Employee.NoCoursesFound;
            }

            return new GetEmployeeCoursesResult()
            {
                Courses = courses
            };
        }
    }
}