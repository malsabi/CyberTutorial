using ErrorOr;

namespace CyberTutorial.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class EmployeeCourse
        {
            public static Error AlreadyExists => Error.Conflict
            (
                code: "EmployeeCourse.AlreadyExists",
                description: "Employee is already registered in this course."
            );

            public static Error NotRegisteredInAllCourses => Error.NotFound
            (
                code: "EmployeeCourse.NotRegisteredInAllCourses",
                description: "Employee is not registered in all courses."
            );
        }
    }
}