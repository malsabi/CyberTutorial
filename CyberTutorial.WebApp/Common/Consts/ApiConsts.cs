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
        public const string GetAllCompanies = "/api/Company/GetAllCompanies";
        public const string GetCompanyById = "/api/Company/GetCompany?companyId={0}";
        public const string GetCompanyBySessionId = "/api/Company/GetCompanyBySessionId?companyId={0}";
        public const string UpdateCompany = "/api/Company/UpdateCompany?companyId={0}";
        public const string DeleteCompany = "/api/Company/DeleteCompany?companyId={0}";
        public const string GetCompanyDashboard = "/api/Company/GetDashboard?companyId={0}";
        public const string IsSessionValidCompany = "/api/Company/IsSessionValid?sessionId={0}&token={1}";
        public const string LogoutCompany = "/api/Company/Logout";
        
        public const string GetAllEmployees = "/api/Employee/GetAllEmployees";
        public const string GetEmployeeById = "/api/Employee/GetEmployee?employeeId={0}";
        public const string GetEmployeeBySessionId = "/api/Employee/GetEmployeeBySessionId?employeeId={0}";
        public const string UpdateEmployee = "/api/Employee/UpdateEmployee?employeeId={0}";
        public const string DeleteEmployee = "/api/Employee/DeleteEmployee?employeeId={0}";
        public const string GetEmployeeDashboard = "/api/Employee/GetDashboard?employeeId={0}";
        public const string IsSessionValidEmployee = "/api/Employee/IsSessionValid?sessionId={0}&token={1}";
        public const string LogoutEmployee = "/api/Employee/Logout";
        #endregion
        #endregion
    }
}