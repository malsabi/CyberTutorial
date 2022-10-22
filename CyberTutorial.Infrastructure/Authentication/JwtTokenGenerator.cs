using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Authentication;

namespace CyberTutorial.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly JwtSettings jwtSettings;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
        {
            this.dateTimeProvider = dateTimeProvider;
            this.jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(Employee employee)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Sid, employee.EmployeeId),
                new Claim(ClaimTypes.Surname, employee.FirstName),
                new Claim(ClaimTypes.GivenName, employee.LastName),
                new Claim(ClaimTypes.Role, "Employee")
            };
            return GenerateToken(claims);
        }

        public string GenerateToken(Company company)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Sid, company.CompanyId),
                new Claim(ClaimTypes.Surname, company.OwnerFirstName),
                new Claim(ClaimTypes.GivenName, company.OwnerLastName),
                new Claim(ClaimTypes.Role, "Company")
            };
            return GenerateToken(claims);
        }

        public string GenerateToken(Administrator administrator)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Sid, administrator.Id),
                new Claim(ClaimTypes.Surname, administrator.Name),
                new Claim(ClaimTypes.Role, "Admin")
            };
            return GenerateToken(claims);
        }

        private string GenerateToken(Claim[] claims)
        {
            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                expires: dateTimeProvider.UtcNow.AddDays(jwtSettings.ExpiryDays),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}