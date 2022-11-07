using ErrorOr;

namespace CyberTutorial.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Document
        {
            public static Error DocumentNotFound => Error.NotFound
            (
                code: "Document.DocumentNotFound",
                description: "Document with given id does not exist."
            );

            public static Error OperationFailed => Error.Failure
            (
                code: "Document.OperationFailed",
                description: "Document operation failed."
            );

            public static Error DocumentFileNotFound => Error.NotFound
            (
                code: "Document.DocumentFileNotFound",
                description: "Document file was not found."
            );
        }
    }
}