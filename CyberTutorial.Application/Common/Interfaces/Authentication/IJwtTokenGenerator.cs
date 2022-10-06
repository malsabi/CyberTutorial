using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Employee employee);
        string GenerateToken(Company company);
        string GenerateToken(Owner owner);
    }
}