using System.ComponentModel.DataAnnotations;

namespace CyberTutorial.WebApp.Models.Employee.Register
{
    public class RegisterEmployeeModel
    {
        [Required(ErrorMessage = "Please insert your Company Id")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Company Id should be 14 characters long")]
        public string CompanyId { get; set; }

        [Required(ErrorMessage = "Please insert your First Name")]
        [MinLength(3, ErrorMessage = "First Name cannot be less than 3 characters")]
        [MaxLength(50, ErrorMessage = "First Name cannot exceed more than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please insert your Last Name")]
        [MinLength(3, ErrorMessage = "Last Name cannot be less than 3 characters")]
        [MaxLength(50, ErrorMessage = "Last Name cannot exceed more than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please insert your Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please insert your Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please insert your Phone Number")]
        [StringLength(10, MinimumLength = 9, ErrorMessage = "Phone Number should be 10 characters long")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please insert your Email Address")]
        [MaxLength(50, ErrorMessage = "Email Address cannot exceed more than 50 characters")]
        [EmailAddress(ErrorMessage = "Please insert a valid Email Address")]
        public string EmailAddress { get; set; }

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