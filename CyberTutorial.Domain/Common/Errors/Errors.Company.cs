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

            public static Error SessionNotFound => Error.NotFound(
                code: "Company.SessionNotFound",
                description: "Company session with given session Id does not exist."
            );

            public static Error InvalidSessionToken => Error.Validation(
                code: "Company.InvalidSessionToken",
                description: "Company token is invalid."
            );

            public static Error OperationFailed => Error.Failure(
                code: "Company.Failure",
                description: "Company operation failed."
            );

            public static Error SessionExpired => Error.Failure(
                code: "Company.SessionExpired",
                description: "Company session has expired."
            );
        }
    }
}