using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Attempts.Common;

namespace CyberTutorial.Application.Attempts.Commands.UpdateAttempt
{
    public class UpdateAttemptCommand : IRequest<ErrorOr<UpdateAttemptResult>>
    {
        public string TargetId { get; set; }
        public string AttemptId { get; set; }
        public string EmployeeId { get; set; }
        public string QuizId { get; set; }
        public string QuizName { get; set; }
        public string StartedAt { get; set; }
        public string CompletedAt { get; set; }
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }
        public int Score { get; set; }
        public int TotalCorrectAnswers { get; set; }
        public int TotalIncorrectAnswers { get; set; }
        public ICollection<Question> AttemptedQuestions { get; set; }
    }
}