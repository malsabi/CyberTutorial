using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Attempts.Common
{
    public class GetAttemptsResult
    {
        public ICollection<Attempt> Attempts { get; set; }
    }
}