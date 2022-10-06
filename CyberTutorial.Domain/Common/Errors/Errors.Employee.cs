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
        }
    }
}