namespace CyberTutorial.WebApp.Common.Consts
{
    public class AppConsts
    {
        #region "ROLES"
        public const string Admin = "Admin";
        public const string Company = "Company";
        public const string Employee = "Employee";
        #endregion

        #region "COOKIES"
        public const int CookieExpirationDays = 30;
        public const string CompanyCookieId = "COMPANY_COOKIE";
        public const string EmployeeCookieId = "EMPLOYEE_COOKIE";
        #endregion

        #region "SERVICES"
        public const string AESKey = "AES:Key";
        public const string AESInitializationVector = "AES:InitializationVector";
        #endregion
    }
}