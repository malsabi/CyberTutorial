using CyberTutorial.Contracts.Models;

namespace CyberTutorial.Contracts.Responses.Attempt
{
    public class GetAttemptsResponse
    {
        public ICollection<AttemptModel> Attempts { get; set; }
    }
}