using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Commands.UpdateEmployeeDashboard
{
    public class UpdateEmployeeDashboardCommand : IRequest<ErrorOr<UpdateEmployeeDashboardResult>>
    {
        public string TargetId { get; set; }
        public string EmployeeDashboardId { get; set; }
        public int TotalCourses { get; set; }
        public string TotalCoursesLastModified { get; set; }
        public int TotalQuizzes { get; set; }
        public string TotalQuizzesLastModified { get; set; }
        public int TotalPassed { get; set; }
        public string TotalPassedLastModified { get; set; }
        public int TotalFailed { get; set; }
        public string TotalFailedLastModified { get; set; }
    }
}