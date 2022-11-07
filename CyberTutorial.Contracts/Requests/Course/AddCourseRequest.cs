namespace CyberTutorial.Contracts.Requests.Course
{
    public class AddCourseRequest
    {
        public string CourseImage { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseUrl { get; set; }
    }
}