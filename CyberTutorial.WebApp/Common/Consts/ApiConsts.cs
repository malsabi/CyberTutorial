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
        #region "Anonymous Endpoints"
        public const string Login = "/api/Authentication/Login";
        public const string RegisterCompany = "/api/Authentication/Register/Company";
        public const string RegisterEmployee = "/api/Authentication/Register/Employee";
        #endregion

        #region "Authorized Endpoints"
        public const string LogoutCompany = "/api/Company/Logout";
        public const string LogoutEmployee = "/api/Employee/Logout";
        public const string IsSessionValidCompany = "/api/Company/IsSessionValid";
        public const string IsSessionValidEmployee = "/api/Employee/IsSessionValid";
        #endregion
        #endregion
    }
}