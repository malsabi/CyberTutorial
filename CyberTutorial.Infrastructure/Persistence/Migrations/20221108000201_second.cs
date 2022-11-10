using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberTutorial.Infrastructure.Persistence.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "1b815c48-5efb-431d-91f7-00503a1840f0");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "6e6270c4-8957-467c-8a9a-8ba292477d0e");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "8d120fe5-8a99-46aa-aa83-5b94abee2588");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "c09572c5-7524-450a-9be3-bc2707b4bdbb");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "c74959d1-c206-4465-a221-ee1cbc0e2b10");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "fefa17f7-8069-435b-8501-daddcc217311");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "ff205a5e-eb22-4546-9b1d-fafa135d2016");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseDescription", "CourseImage", "CourseName", "CourseUrl" },
                values: new object[,]
                {
                    { "2cd7a7d7-054b-4fad-8ae6-2310ca92d609", "A document that you should ideally give to each employee upon hiring. Prospective employees should read the policy, sign it, and date it before they start work.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Email And Internet Usage Policy", "https://localhost:7196/api/Document/Download?documentId=342c4724-0aeb-4d69-ba8f-12424e49274a" },
                    { "42ef5e92-3da4-48f6-8d13-6da0326a3e58", "You'll learn about mobile security vulnerabilities and threats in this in-depth exploration of mobile security in the company.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Mobile Device Security", "https://localhost:7196/api/Document/Download?documentId=44fd3336-21d9-4bf7-8b6a-c85d1a4082ef" },
                    { "4ff39251-8cc2-4819-8b30-7fe544f8bd08", "describes measures designed to ensure the physical protection of IT assets such as facilities, equipment and other property from damage and unauthorized physical access.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Physical Security", "https://localhost:7196/api/Document/Download?documentId=f4b013a6-b2dd-415c-91f7-54c4b49f5de7" },
                    { "8d97ee89-cb8b-47ea-b59e-ac276866fe4e", "A manipulation technique that exploits human error to gain private information, access, or valuables.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Social Engineering", "https://localhost:7196/api/Document/Download?documentId=4451fdbd-d680-4633-b552-6a746aa8cc9c" },
                    { "b8623275-c5cd-4f27-bdbb-75b9d9fb5b84", "Fake communications that appear to come froma trusted source, but these communications can put all kinds of your data at risk.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Phishing Attacks", "https://localhost:7196/api/Document/Download?documentId=15098b99-f2c0-42a9-9cd0-499a4ba0875d" },
                    { "ddec3205-e85f-4b75-a277-ce3db9f4dd6d", "A collection of procedures and technology designed to address external and internal threats to business security.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Cloud Security", "https://localhost:7196/api/Document/Download?documentId=c723b5e9-9971-467f-ac32-88beda990cbf" },
                    { "de88a0ef-cd13-4179-a181-18c1d3bdff99", "Found in popular public places like airports, coffee shops, malls, restaurants, and hotels and it allows you to access the internet for free.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Public Wi-Fi", "https://localhost:7196/api/Document/Download?documentId=b97f6cf2-cf17-4abe-9b1c-c4a862701bf8" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "2cd7a7d7-054b-4fad-8ae6-2310ca92d609");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "42ef5e92-3da4-48f6-8d13-6da0326a3e58");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "4ff39251-8cc2-4819-8b30-7fe544f8bd08");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "8d97ee89-cb8b-47ea-b59e-ac276866fe4e");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "b8623275-c5cd-4f27-bdbb-75b9d9fb5b84");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "ddec3205-e85f-4b75-a277-ce3db9f4dd6d");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "de88a0ef-cd13-4179-a181-18c1d3bdff99");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseDescription", "CourseImage", "CourseName", "CourseUrl" },
                values: new object[,]
                {
                    { "1b815c48-5efb-431d-91f7-00503a1840f0", "You'll learn about mobile security vulnerabilities and threats in this in-depth exploration of mobile security in the company.", "", "Mobile Device Security", "" },
                    { "6e6270c4-8957-467c-8a9a-8ba292477d0e", "describes measures designed to ensure the physical protection of IT assets such as facilities, equipment and other property from damage and unauthorized physical access.", "", "Physical Security", "" },
                    { "8d120fe5-8a99-46aa-aa83-5b94abee2588", "A collection of procedures and technology designed to address external and internal threats to business security.", "", "Cloud Security", "" },
                    { "c09572c5-7524-450a-9be3-bc2707b4bdbb", "A manipulation technique that exploits human error to gain private information, access, or valuables.", "", "Social Engineering", "" },
                    { "c74959d1-c206-4465-a221-ee1cbc0e2b10", "Found in popular public places like airports, coffee shops, malls, restaurants, and hotels and it allows you to access the internet for free.", "", "Public Wi-Fi", "" },
                    { "fefa17f7-8069-435b-8501-daddcc217311", "Fake communications that appear to come froma trusted source, but these communications can put all kinds of your data at risk.", "", "Phishing Attacks", "" },
                    { "ff205a5e-eb22-4546-9b1d-fafa135d2016", "A document that you should ideally give to each employee upon hiring. Prospective employees should read the policy, sign it, and date it before they start work.", "", "Email And Internet Usage Policy", "" }
                });
        }
    }
}
