using ErrorOr;

namespace CyberTutorial.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Course
        {
            public static Error DuplicateCourse => Error.Conflict
            (
                code: "Course.DuplicateCourse",
                description: "Course with this name already exists."
            );

            public static Error NotFound => Error.NotFound
            (
                code: "Course.NotFound",
                description: "Course with given id does not exist."
            );

            public static Error OperationFailed => Error.Failure
            (
                code: "Course.OperationFailed",
                description: "Course operation failed."
            );
        }
    }
}