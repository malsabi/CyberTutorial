using ErrorOr;

namespace CyberTutorial.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Attempt
        {
            public static Error AttemptNotFound => Error.NotFound
            (
                code: "Attempt.AttemptNotFound",
                description: "Attempt with given id does not exist."
            );

            public static Error OperationFailed => Error.Failure
            (
                code: "Attempt.OperationFailed",
                description: "Attempt operation failed."
            );
        }
    }
}