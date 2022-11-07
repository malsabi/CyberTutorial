using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Courses.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;


namespace CyberTutorial.Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, ErrorOr<UpdateCourseResult>>
    {
        private readonly IMapper mapper;
        private readonly ICourseRepository courseRepository;

        public UpdateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository)
        {
            this.mapper = mapper;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<UpdateCourseResult>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            if (request.CourseId != request.TargetId)
            {
                return Errors.Course.OperationFailed;
            }

            if (await courseRepository.GetCourseByIdAsync(request.CourseId) is not Course course)
            {
                return Errors.Course.NotFound;
            }

            course.CourseName = request.CourseName;
            course.CourseImage = request.CourseImage;
            course.CourseDescription = request.CourseDescription;
            course.CourseUrl = request.CourseUrl;

            await courseRepository.UpdateCourseAsync(course);

            return mapper.Map<UpdateCourseResult>(course);
        }
    }
}