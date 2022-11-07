using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Courses.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Courses.Commands.AddCourse
{
    public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, ErrorOr<AddCourseResult>>
    {
        private readonly IMapper mapper;
        private readonly ICourseRepository courseRepository;

        public AddCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository)
        {
            this.mapper = mapper;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<AddCourseResult>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            if (await courseRepository.GetCourseByNameAsync(request.CourseName) is not null)
            {
                return Errors.Course.DuplicateCourse;
            }

            Course course = mapper.Map<Course>(request);
            course.CourseId = Guid.NewGuid().ToString();

            await courseRepository.AddCourseAsync(course);

            return mapper.Map<AddCourseResult>(course);
        }
    }
}