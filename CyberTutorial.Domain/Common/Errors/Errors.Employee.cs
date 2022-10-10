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
        }
    }
}