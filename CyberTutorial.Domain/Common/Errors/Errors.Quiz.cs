using ErrorOr;

namespace CyberTutorial.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Quiz
        {
            public static Error DuplicateQuiz => Error.Conflict
            (
               code: "Quiz.DuplicateQuiz",
               description: "Quiz with this Id already exists."
            );

            public static Error QuizNotFound => Error.NotFound
            (
                code: "Quiz.QuizNotFound",
                description: "Quiz with given id does not exist."
            );

            public static Error OperationFailed => Error.Failure
            (
                code: "Quiz.OperationFailed",
                description: "Quiz operation failed."
            );
        }
    }
}