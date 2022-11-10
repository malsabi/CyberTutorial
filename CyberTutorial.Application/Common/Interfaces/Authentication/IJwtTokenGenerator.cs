using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Employee employee);   //Token JWT (Jason Web Token)
        string GenerateToken(Company company);     //Token JWT (Jason Web Token)
        string GenerateToken(Administrator owner); //Token JWT (Jason Web Token)
    }
}