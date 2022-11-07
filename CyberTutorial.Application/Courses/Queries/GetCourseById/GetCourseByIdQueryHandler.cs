using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Courses.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, ErrorOr<GetCourseByIdResult>>
    {
        private readonly IMapper mapper;
        private readonly ICourseRepository courseRepository;

        public GetCourseByIdQueryHandler(IMapper mapper, ICourseRepository courseRepository)
        {
            this.mapper = mapper;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<GetCourseByIdResult>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            if (await courseRepository.GetCourseByIdAsync(request.CourseId) is not Course course)
            {
                return Errors.Course.NotFound;
            }
            return mapper.Map<GetCourseByIdResult>(course);
        }
    }
}