using System.ComponentModel.DataAnnotations;

namespace CyberTutorial.Contracts.Models
{
    public class RegisterModel
    {
        public RegisterCompanyModel RegisterCompanyModel { get; set; }
        public RegisterEmployeeModel RegisterEmployeeModel { get; set; }

        public RegisterModel()
        {
            RegisterCompanyModel = new RegisterCompanyModel();
            RegisterEmployeeModel = new RegisterEmployeeModel();
        }
    }
}