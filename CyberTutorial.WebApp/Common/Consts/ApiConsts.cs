namespace CyberTutorial.WebApp.Common.Consts
{
    public static class ApiConsts
    {
        #region "BaseAddress"
        public const string LocalEndPoint = "Api:LocalApiEndPoint";
        public const string WebEndPoint = "Api:PublishedApiEndPoint";
        #endregion

        #region "Authorization & Authentication"
        public const string Scheme = "Bearer";
        #endregion

        #region "Api Endpoints"
        public static class Authentication
        {
            public const string RegisterCompany = "/api/Authentication/Register/Company";
            public const string RegisterEmployee = "/api/Authentication/Register/Employee";
            public const string LoginCompany = "/api/Authentication/Login/Company";
            public const string LoginEmployee = "/api/Authentication/Login/Employee";
            public const string LogoutCompany = "/api/Authentication/Logout/Company";
            public const string LogoutEmployee = "/api/Authentication/Logout/Employee";
        }

        public static class Company
        {
            public const string Add = "/api/Company/Add";
            public const string GetAll = "/api/Company/GetAll";
            public const string Get = "/api/Company/Get?companyId={0}";
            public const string GetAllEmployees = "/api/Company/GetAllEmployees?companyId={0}";
            public const string GetSession = "/api/Company/GetSession?companyId={0}";
            public const string Update = "/api/Company/Update?companyId={0}";
            public const string UpdateSession = "/api/Company/UpdateSession?companyId={0}";
            public const string Delete = "/api/Company/Delete?companyId={0}";
        }

        public static class Employee
        {
            public const string Add = "/api/Employee/Add";
            public const string GetAll = "/api/Employee/GetAll";
            public const string Get = "/api/Employee/Get?employeeId={0}";
            public const string GetCompany = "/api/Employee/GetCompany?employeeId={0}";
            public const string GetSession = "/api/Employee/GetSession?employeeId={0}";
            public const string GetDashboard = "/api/Employee/GetDashboard?employeeId={0}";
            public const string Update = "/api/Employee/Update?employeeId={0}";
            public const string UpdateSession = "/api/Employee/UpdateSession?employeeId={0}";
            public const string UpdateDashboard = "/api/Employee/UpdateDashboard?employeeId={0}";
            public const string Delete = "/api/Employee/Delete?employeeId={0}";
        }

        public static class EmployeeCourse
        {
            public const string Add = "/api/EmployeeCourse/Add?employeeId={0}&courseId={1}";
            public const string GetAll = "/api/EmployeeCourse/GetAll?employeeId={0}";
            public const string Get = "/api/EmployeeCourse/Get?employeeId={0}&courseId={1}";
            public const string DeleteAll = "/api/EmployeeCourse/DeleteAll?employeeId={0}";
            public const string Delete = "/api/EmployeeCourse/Delete?employeeId={0}&courseId={1}";
        }

        public static class Attempt
        {
            public const string Add = "/api/Attempt/Add";
            public const string GetAll = "/api/Attempt/GetAll";
            public const string Get = "/api/Attempt/Get?attemptId={0}";
            public const string Update = "/api/Attempt/Update?attemptId={0}";
            public const string Delete = "/api/Attempt/Delete?attemptId={0}";
        }

        public static class Course
        {
            public const string Add = "/api/Course/Add";
            public const string GetAll = "/api/Course/GetAll";
            public const string Get = "/api/Course/Get?courseId={0}";
            public const string Update = "/api/Course/Update?courseId={0}";
            public const string Delete = "/api/Course/Delete?courseId={0}";
        }

        public static class Quiz
        {
            public const string Add = "/api/Quiz/Add";
            public const string GetAll = "/api/Quiz/GetAll";
            public const string Get = "/api/Quiz/Get?quizId={0}";
            public const string Update = "/api/Quiz/Update?quizId={0}";
            public const string Delete = "/api/Quiz/Delete?quizId={0}";
        }

        public static class Document
        {
            public const string Upload = "/api/Document/Upload";
            public const string Download = "/api/Document/Download?documentId={0}";
        }
        #endregion
    }
}