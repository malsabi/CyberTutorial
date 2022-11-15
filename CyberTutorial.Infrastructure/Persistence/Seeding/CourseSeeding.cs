using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Infrastructure.Persistence.Seeding
{
    public static class CourseSeeding
    {
        public static List<Course> Courses()
        {
            return new List<Course>()
            {
                new Course()
                {
                   CourseId = Guid.NewGuid().ToString(),
                   CourseImage = "https://localhost:7196/api/Document/Get?documentId=83017331-5426-47f9-ac19-31aaef08bea7",
                   CourseName = "Cloud Security",
                   CourseDescription = "A collection of procedures and technology designed to address external and internal threats to business security.",
                   CourseUrl = "https://localhost:7196/api/Document/Get?documentId=c723b5e9-9971-467f-ac32-88beda990cbf"
                },
                new Course()
                {
                   CourseId = Guid.NewGuid().ToString(),
                   CourseImage = "https://localhost:7196/api/Document/Get?documentId=83017331-5426-47f9-ac19-31aaef08bea7",
                   CourseName = "Email And Internet Usage Policy",
                   CourseDescription = "A document that you should ideally give to each employee upon hiring. Prospective employees should read the policy, sign it, and date it before they start work.",
                   CourseUrl = "https://localhost:7196/api/Document/Get?documentId=342c4724-0aeb-4d69-ba8f-12424e49274a"
                },
                new Course()
                {
                   CourseId = Guid.NewGuid().ToString(),
                   CourseImage = "https://localhost:7196/api/Document/Get?documentId=83017331-5426-47f9-ac19-31aaef08bea7",
                   CourseName = "Mobile Device Security",
                   CourseDescription = "You'll learn about mobile security vulnerabilities and threats in this in-depth exploration of mobile security in the company.",
                   CourseUrl = "https://localhost:7196/api/Document/Get?documentId=44fd3336-21d9-4bf7-8b6a-c85d1a4082ef"
                },
                new Course()
                {
                   CourseId = Guid.NewGuid().ToString(),
                   CourseImage = "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7",
                   CourseName = "Phishing Attacks",
                   CourseDescription = "Fake communications that appear to come froma trusted source, but these communications can put all kinds of your data at risk.",
                   CourseUrl = "https://localhost:7196/api/Document/Download?documentId=15098b99-f2c0-42a9-9cd0-499a4ba0875d"
                },
                new Course()
                {
                   CourseId = Guid.NewGuid().ToString(),
                   CourseImage = "https://localhost:7196/api/Document/Get?documentId=83017331-5426-47f9-ac19-31aaef08bea7",
                   CourseName = "Physical Security",
                   CourseDescription = "describes measures designed to ensure the physical protection of IT assets such as facilities, equipment and other property from damage and unauthorized physical access.",
                   CourseUrl = "https://localhost:7196/api/Document/Get?documentId=f4b013a6-b2dd-415c-91f7-54c4b49f5de7"
                },
                new Course()
                {
                   CourseId = Guid.NewGuid().ToString(),
                   CourseImage = "https://localhost:7196/api/Document/Get?documentId=83017331-5426-47f9-ac19-31aaef08bea7",
                   CourseName = "Public Wi-Fi",
                   CourseDescription = "Found in popular public places like airports, coffee shops, malls, restaurants, and hotels and it allows you to access the internet for free.",
                   CourseUrl = "https://localhost:7196/api/Document/Get?documentId=b97f6cf2-cf17-4abe-9b1c-c4a862701bf8"
                },
                new Course()
                {
                   CourseId = Guid.NewGuid().ToString(),
                   CourseImage = "https://localhost:7196/api/Document/Get?documentId=83017331-5426-47f9-ac19-31aaef08bea7",
                   CourseName = "Social Engineering",
                   CourseDescription = "A manipulation technique that exploits human error to gain private information, access, or valuables.",
                   CourseUrl = "https://localhost:7196/api/Document/Get?documentId=4451fdbd-d680-4633-b552-6a746aa8cc9c"
                }
            };
        }
    }
}