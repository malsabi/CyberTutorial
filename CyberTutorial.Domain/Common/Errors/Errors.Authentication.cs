using ErrorOr;

namespace CyberTutorial.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error DoesNotExists => Error.Validation(
                code: "Authentication.DoesNotExists",
                description: "The given email does not exist."
            );

            public static Error InvalidPassword => Error.Validation(
                code: "Authentication.InvalidCredentials",
                description: "Invalid password"
            );
        }
    }
}