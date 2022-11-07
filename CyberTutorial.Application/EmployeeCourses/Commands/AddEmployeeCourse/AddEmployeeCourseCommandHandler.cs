using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.EmployeeCourses.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.EmployeeCourses.Commands.AddEmployeeCourse
{
    public class AddEmployeeCourseCommandHandler : IRequestHandler<AddEmployeeCourseCommand, ErrorOr<AddEmployeeCourseResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICourseRepository courseRepository;

        public AddEmployeeCourseCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository, ICourseRepository courseRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<AddEmployeeCourseResult>> Handle(AddEmployeeCourseCommand request, CancellationToken cancellationToken)
        {
            if (await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId) is not Employee employee)
            {
                return Errors.Employee.NotFound;
            }

            if (await courseRepository.GetCourseByIdAsync(request.CourseId) is not Course course)
            {
                return Errors.Course.NotFound;
            }

            if (course.Employees.Any(e => e.EmployeeId == employee.EmployeeId))
            {
                return Errors.EmployeeCourse.AlreadyExists;
            }

            if (employee.Courses.Any(c => c.CourseId == course.CourseId))
            {
                return Errors.EmployeeCourse.AlreadyExists;
            }

            course.Employees.Add(employee);
            employee.Courses.Add(course);
            await courseRepository.UpdateCourseAsync(course);
            await employeeRepository.UpdateEmployeeAsync(employee);

            return mapper.Map<AddEmployeeCourseResult>(course);
        }
    }
}