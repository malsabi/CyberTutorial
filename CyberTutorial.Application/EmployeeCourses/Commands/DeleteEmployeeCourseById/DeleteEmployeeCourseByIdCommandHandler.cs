using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.EmployeeCourses.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.EmployeeCourses.Commands.DeleteEmployeeCourseById
{
    public class DeleteEmployeeCourseByIdCommandHandler : IRequestHandler<DeleteEmployeeCourseByIdCommand, ErrorOr<DeleteEmployeeCourseByIdResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICourseRepository courseRepository;

        public DeleteEmployeeCourseByIdCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository, ICourseRepository courseRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<DeleteEmployeeCourseByIdResult>> Handle(DeleteEmployeeCourseByIdCommand request, CancellationToken cancellationToken)
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

            Course course = courses.FirstOrDefault(c => c.CourseId == request.CourseId);

            if (course == null)
            {
                return Errors.Employee.CourseNotFound;
            }

            courses.Remove(course);
            await employeeRepository.UpdateEmployeeAsync(employee);

            return mapper.Map<DeleteEmployeeCourseByIdResult>(course);
        }
    }
}