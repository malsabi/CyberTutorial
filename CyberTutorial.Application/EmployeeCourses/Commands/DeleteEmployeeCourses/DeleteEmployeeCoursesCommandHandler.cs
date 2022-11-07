using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.EmployeeCourses.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.EmployeeCourses.Commands.DeleteEmployeeCourses
{
    public class DeleteEmployeeCoursesCommandHandler : IRequestHandler<DeleteEmployeeCoursesCommand, ErrorOr<DeleteEmployeeCoursesResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICourseRepository courseRepository;

        public DeleteEmployeeCoursesCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository, ICourseRepository courseRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<DeleteEmployeeCoursesResult>> Handle(DeleteEmployeeCoursesCommand request, CancellationToken cancellationToken)
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

            List<Course> courses = (List<Course>)employee.Courses;

            if (courses == null || courses.Count == 0)
            {
                return Errors.Employee.NoCoursesFound;
            }

            List<string> coursesId = courses.Select(c => c.CourseId).ToList();

            courses.Clear();

            await employeeRepository.UpdateEmployeeAsync(employee);

            return mapper.Map<DeleteEmployeeCoursesResult>(coursesId);
        }
    }
}