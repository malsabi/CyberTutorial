using Moq;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.API.Testing.Mocks
{
    public  class MockCompanyRepository
    {
        public static Mock<ICompanyRepository> GetCompanyRepository()
        {
            List<Company> companies = new List<Company>()
            {
                new Company()
                {
                    CompanyId = "1",
                    CompanyName = "CyberTutorial",
                    OwnerFirstName = "John",
                    OwnerLastName = "Doe",
                    OwnerEmiratesId = "111-2222-3334445-9",
                    PhoneNumber = "0501231234",
                    EmailAddress = "JohnDoe@gmail.com",
                    State = "Dubai",
                    Region = "Dubai",
                    StreetAddress = "Dubai Silicon Oasis",
                    Website = "https://cyber-tutorials.com",
                    CompanyDescription = "Digital cyber security awareness.",
                    Password = "123321",
                    Session = new CompanySession()
                    {
                        CompanySessionId = "1",
                        TimeCreated = DateTime.Now.ToString(),
                        ExpiryDate = DateTime.Now.AddDays(30).ToString(),
                        Token = "CompanyTempToken",
                        IsActive = true
                    }
                }
            };

            Mock<ICompanyRepository> mock = new Mock<ICompanyRepository>();

            mock.Setup(s => s.AddCompanyAsync(It.IsAny<Company>())).Returns((Company company) =>
            {
                companies.Add(company);
                return Task.CompletedTask;
            });
            
            mock.Setup(s => s.GetCompaniesAsync()).ReturnsAsync(companies);
            
            mock.Setup(s => s.GetCompanyByIdAsync(It.IsAny<string>())).ReturnsAsync((string id) =>
            {
                return companies.FirstOrDefault(c => c.CompanyId == id);
            });
            
            mock.Setup(s => s.GetCompanyByEmailAsync(It.IsAny<string>())).ReturnsAsync((string email) =>
            {
                return companies.FirstOrDefault(c => c.EmailAddress == email);
            });

            mock.Setup(s => s.UpdateCompanyAsync(It.IsAny<Company>())).Returns((Company company) =>
            {
                int index = companies.FindIndex(c => c.CompanyId == company.CompanyId);
                companies[index] = company;
                return Task.CompletedTask;
            });
            
            mock.Setup(s => s.DeleteCompanyAsync(It.IsAny<Company>())).Returns((Company company) =>
            {
                companies.Remove(company);
                return Task.CompletedTask;
            });
            
            return mock;
        }
    }
}