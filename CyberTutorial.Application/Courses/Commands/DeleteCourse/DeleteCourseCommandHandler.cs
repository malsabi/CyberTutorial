using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Courses.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, ErrorOr<DeleteCourseResult>>
    {
        private readonly IMapper mapper;
        private readonly ICourseRepository courseRepository;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }

        public async Task<ErrorOr<DeleteCourseResult>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            if (await courseRepository.GetCourseByIdAsync(request.CourseId) is not Course course)
            {
                return Errors.Course.NotFound;
            }

            await courseRepository.DeleteCourseAsync(course);

            return mapper.Map<DeleteCourseResult>(course);
        }
    }
}