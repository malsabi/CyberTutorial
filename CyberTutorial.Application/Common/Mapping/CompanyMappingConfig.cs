using Mapster;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Companies.Common;

namespace CyberTutorial.Application.Common.Mapping
{
    public class CompanyMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Company, GetCompanyByIdResult>()
                .Map(dest => dest.Company.CompanyId, src => src.CompanyId)
                .Map(dest => dest.Company.CompanyName, src => src.CompanyName)
                .Map(dest => dest.Company.OwnerFirstName, src => src.OwnerFirstName)
                .Map(dest => dest.Company.OwnerLastName, src => src.OwnerLastName)
                .Map(dest => dest.Company.OwnerEmiratesId, src => src.OwnerEmiratesId)
                .Map(dest => dest.Company.PhoneNumber, src => src.PhoneNumber)
                .Map(dest => dest.Company.EmailAddress, src => src.EmailAddress)
                .Map(dest => dest.Company.State, src => src.State)
                .Map(dest => dest.Company.Region, src => src.Region)
                .Map(dest => dest.Company.StreetAddress, src => src.StreetAddress)
                .Map(dest => dest.Company.Website, src => src.Website)
                .Map(dest => dest.Company.CompanyDescription, src => src.CompanyDescription)
                .Map(dest => dest.Company.Password, src => src.Password);

            config.NewConfig<Company, GetCompanySessionResult>()
                .Map(dest => dest.Session.CompanySessionId, src => src.Session.CompanySessionId)
                .Map(dest => dest.Session.TimeCreated, src => src.Session.TimeCreated)
                .Map(dest => dest.Session.ExpiryDate, src => src.Session.ExpiryDate)
                .Map(dest => dest.Session.Token, src => src.Session.Token)
                .Map(dest => dest.Session.IsActive, src => src.Session.IsActive);

            config.NewConfig<Company, UpdateCompanyResult>()
                .Map(dest => dest.Company.CompanyId, src => src.CompanyId)
                .Map(dest => dest.Company.CompanyName, src => src.CompanyName)
                .Map(dest => dest.Company.OwnerFirstName, src => src.OwnerFirstName)
                .Map(dest => dest.Company.OwnerLastName, src => src.OwnerLastName)
                .Map(dest => dest.Company.OwnerEmiratesId, src => src.OwnerEmiratesId)
                .Map(dest => dest.Company.PhoneNumber, src => src.PhoneNumber)
                .Map(dest => dest.Company.EmailAddress, src => src.EmailAddress)
                .Map(dest => dest.Company.State, src => src.State)
                .Map(dest => dest.Company.Region, src => src.Region)
                .Map(dest => dest.Company.StreetAddress, src => src.StreetAddress)
                .Map(dest => dest.Company.Website, src => src.Website)
                .Map(dest => dest.Company.CompanyDescription, src => src.CompanyDescription)
                .Map(dest => dest.Company.Password, src => src.Password);
        }
    }
}