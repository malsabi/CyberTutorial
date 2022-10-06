﻿using ErrorOr;
using MediatR;
using CyberTutorial.Application.Authentication.Common;

namespace CyberTutorial.Application.Authentication.Queries
{
    public class LoginEmployeeQuery : IRequest<ErrorOr<LoginResult>>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}