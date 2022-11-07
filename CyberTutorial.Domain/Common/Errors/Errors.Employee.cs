using ErrorOr;

namespace CyberTutorial.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Employee
        {
            public static Error DuplicateEmail => Error.Conflict(
              code: "Employee.DuplicateEmail",
              description: "Employee with this email already exists."
            );

            public static Error NotFound => Error.NotFound(
                code: "Employee.NotFound",
                description: "Employee with given id does not exist."
            );

            public static Error SessionNotFound => Error.NotFound(
              code: "Employee.SessionNotFound",
              description: "Employee session with given session Id does not exist."
            );

            public static Error InvalidSessionToken => Error.Validation(
                code: "Employee.InvalidSessionToken",
                description: "Employee token is invalid."
            );

            public static Error OperationFailed => Error.Failure(
                code: "Employee.Failure",
                description: "Employee operation failed."
            );

            public static Error SessionExpired => Error.Failure(
                code: "Employee.SessionExpired",
                description: "Employee session has expired."
            );

            public static Error NoEmployeesFound => Error.NotFound(
                code: "Employee.NoEmployeesFound",
                description: "No employees found."
            );

            public static Error CourseNotFound => Error.NotFound(
                code: "Employee.CourseNotFound",
                description: "Employee course with given id does not exist."
            );

            public static Error NoCoursesFound => Error.NotFound(
                code: "Employee.NoCoursesFound",
                description: "No courses were found for the given employee id."
            );

            public static Error QuizNotFound => Error.NotFound(
                code: "Employee.QuizNotFound",
                description: "Employee quiz with given id does not exist."
            );

            public static Error NoQuizzesFound => Error.NotFound(
                code: "Employee.NoQuizzesFound",
                description: "No quizzes were found for the given employee id."
            );

            public static Error NoDashboardFound => Error.NotFound(
                code: "Employee.NoDashboardFound",
                description: "Employee dashboard does not exists"
            );
        }
    }
}