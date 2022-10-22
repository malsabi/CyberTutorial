using System.ComponentModel.DataAnnotations;

namespace CyberTutorial.WebApp.Models.Company.Register
{
    public class RegisterCompanyModel
    {
        [Required(ErrorMessage = "Please insert your Business Name")]
        [MinLength(3, ErrorMessage = "Business Name cannot be less than 3 characters")]
        [MaxLength(200, ErrorMessage = "Business Name cannot exceed more than 200 characters")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please insert your First Name")]
        [MinLength(3, ErrorMessage = "First Name cannot be less than 3 characters")]
        [MaxLength(50, ErrorMessage = "First Name cannot exceed more than 50 characters")]
        public string OwnerFirstName { get; set; }

        [Required(ErrorMessage = "Please insert your Last Name")]
        [MinLength(3, ErrorMessage = "Last Name cannot be less than 3 characters")]
        [MaxLength(50, ErrorMessage = "Last Name cannot exceed more than 50 characters")]
        public string OwnerLastName { get; set; }

        [Required(ErrorMessage = "Please insert your Emirates Id")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "Emirates Id should be 18 characters long")]
        public string OwnerEmiratesId { get; set; }

        [Required(ErrorMessage = "Please insert your Phone Number")]
        [StringLength(10, MinimumLength = 9, ErrorMessage = "Phone Number should be 10 characters long")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please insert your Email Address")]
        [MaxLength(50, ErrorMessage = "Email Address cannot exceed more than 50 characters")]
        [EmailAddress(ErrorMessage = "Please insert a valid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please insert your State")]
        [MinLength(3, ErrorMessage = "State cannot be less than 3 characters")]
        [MaxLength(50, ErrorMessage = "State cannot exceed more than 50 characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please insert your Region")]
        [MinLength(3, ErrorMessage = "Region cannot be less than 3 characters")]
        [MaxLength(50, ErrorMessage = "Region cannot exceed more than 50 characters")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Please insert your Street Address")]
        [MinLength(3, ErrorMessage = "Street Address cannot be less than 3 characters")]
        [MaxLength(200, ErrorMessage = "Street Address cannot exceed more than 200 characters")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Please insert your Website")]
        [Url(ErrorMessage = "Please insert a valid Website")]
        public string Website { get; set; }

        [Required(ErrorMessage = "Please insert your Password")]
        [MinLength(6, ErrorMessage = "Password cannot be less than 6 characters")]
        [MaxLength(50, ErrorMessage = "Password cannot exceed more than 50 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please insert your Confirm Password")]
        [MinLength(6, ErrorMessage = "Password cannot be less than 6 characters")]
        [MaxLength(50, ErrorMessage = "Confirm Password cannot exceed more than 50 characters")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}