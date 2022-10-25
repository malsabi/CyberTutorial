﻿using ErrorOr;
using MediatR;
using CyberTutorial.Application.Companies.Common;

namespace CyberTutorial.Application.Companies.Commands.LogoutCompany
{
    public class LogoutCompanyCommand : IRequest<ErrorOr<LogoutCompanyResult>>
    {
        public string SessionId { get; set; }
        public string Token { get; set; }
    }
}