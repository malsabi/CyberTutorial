using CyberTutorial.WebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace CyberTutorial.WebApp.ViewModels
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