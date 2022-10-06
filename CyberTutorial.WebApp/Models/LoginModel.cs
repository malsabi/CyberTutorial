using CyberTutorial.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace CyberTutorial.WebApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please insert your Email")]
        [MaxLength(50, ErrorMessage = "Email cannot exceed more than 50 characters")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please insert your password")]
        [MaxLength(50, ErrorMessage = "Password cannot exceed more than 50 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please insert your Account Type")]
        public AccountType AccountType { get; set; }
    }
}