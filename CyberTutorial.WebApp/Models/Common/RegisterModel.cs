using System.ComponentModel.DataAnnotations;
using CyberTutorial.WebApp.Models.Company.Register;
using CyberTutorial.WebApp.Models.Employee.Register;

namespace CyberTutorial.WebApp.Models.Common
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