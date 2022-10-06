﻿using CyberTutorial.Contracts.Enums;

namespace CyberTutorial.Contracts.Authentication.Request
{
    public class LoginRequest
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public AccountType AccountType { get; set; }
    }
}