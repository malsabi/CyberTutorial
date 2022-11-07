using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Courses.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Courses.Queries.GetCourses
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, GetCoursesResult>
    {
        private readonly ICourseRepository courseRepository;

        public GetCoursesQueryHandler(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<GetCoursesResult> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            ICollection<Course> courses = await courseRepository.GetCoursesAsync();
            return new GetCoursesResult()
            {
                Courses = courses
            };
        }
    }
}