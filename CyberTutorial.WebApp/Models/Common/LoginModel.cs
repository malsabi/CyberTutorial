using CyberTutorial.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace CyberTutorial.WebApp.Models.Common
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please insert your Email")]
        [MaxLength(50, ErrorMessage = "Email cannot exceed more than 50 characters")]
        [EmailAddress(ErrorMessage = "Please insert a valid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please insert your password")]
        [MaxLength(50, ErrorMessage = "Password cannot exceed more than 50 characters")]
        [MinLength(6, ErrorMessage = "Password cannot be less than 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please insert your Account Type")]
        public AccountType AccountType { get; set; }
    }
}