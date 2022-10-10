namespace CyberTutorial.WebApp.Common.Consts
{
    public class ApiConsts
    {
        #region "BaseAddress"
        public const string LocalEndPoint = "Api:LocalApiEndPoint";
        public const string WebEndPoint = "Api:PublishedApiEndPoint";
        #endregion

        #region "Authorization & Authentication"
        public const string Scheme = "Bearer";
        #endregion

        #region "Api Endpoints"
        //Anonymous
        public const string Login = "/Auth/Login";
        public const string RegisterCompany = "api/Register/Company";
        public const string RegisterEmployee = "/api/Register/Employee";
        //Authorization
        public const string LogoutCompany = "/api/Company/Logout";
        public const string LogoutEmployee = "/api/Employee/Logout";
        #endregion
    }
}