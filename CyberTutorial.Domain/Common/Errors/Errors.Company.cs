using ErrorOr;

namespace CyberTutorial.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Company
        {
            public static Error DuplicateEmail => Error.Conflict(
               code: "Company.DuplicateEmail",
               description: "Company with this email already exists."
            );

            public static Error NotFound => Error.NotFound(
                code: "Company.NotFound",
                description: "Company with given id does not exist."
            );
        }
    }
}