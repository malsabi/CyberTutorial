using Mapster;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Authentication.Common;

namespace CyberTutorial.Application.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CompanySession, LoginCompanyResult>()
                  .Map(dest => dest.Session.CompanySessionId, src => src.CompanySessionId)
                  .Map(dest => dest.Session.TimeCreated, src => src.TimeCreated)
                  .Map(dest => dest.Session.ExpiryDate, src => src.ExpiryDate)
                  .Map(dest => dest.Session.Token, src => src.Token)
                  .Map(dest => dest.Session.IsActive, src => src.IsActive);

            config.NewConfig<EmployeeSession, LoginEmployeeResult>()
                  .Map(dest => dest.Session.EmployeeSessionId, src => src.EmployeeSessionId)
                  .Map(dest => dest.Session.TimeCreated, src => src.TimeCreated)
                  .Map(dest => dest.Session.ExpiryDate, src => src.ExpiryDate)
                  .Map(dest => dest.Session.Token, src => src.Token)
                  .Map(dest => dest.Session.IsActive, src => src.IsActive);
        }
    }
}