using CyberTutorial.Application.Common.Interfaces.Services;

namespace CyberTutorial.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}