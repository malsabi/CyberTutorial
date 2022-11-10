using Mapster;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Authentication.Common;

namespace CyberTutorial.API.Testing.Mappings
{
    public static class LoginCompanyConfigMapping
    {
        public static TypeAdapterConfig GetConfig()
        {
            TypeAdapterConfig config = new TypeAdapterConfig();
            config.NewConfig<CompanySession, LoginCompanyResult>()
                  .Map(dest => dest.Session.CompanySessionId, src => src.CompanySessionId)
                  .Map(dest => dest.Session.TimeCreated, src => src.TimeCreated)
                  .Map(dest => dest.Session.ExpiryDate, src => src.ExpiryDate)
                  .Map(dest => dest.Session.Token, src => src.Token)
                  .Map(dest => dest.Session.IsActive, src => src.IsActive);
            return config;
        }
    }
}