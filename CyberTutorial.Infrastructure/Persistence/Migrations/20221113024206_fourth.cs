using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberTutorial.Infrastructure.Persistence.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "01ccac23-bf0d-4dd2-8ef4-6da7a68d9d55");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "0706291e-019d-4e12-8466-2c25ccb59423");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "0b5be3ac-26ff-44bc-8441-0418fda1e182");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "223c2eb9-fac4-4d3a-9c6f-97275952fbd6");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "63348933-17e6-4973-8726-95ee3ca79af1");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "a216c3ad-5caf-435b-8b15-c365829d2972");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: "cd9592f9-4c69-4cb2-8ed6-9c098b5da3d6");

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "QuizId",
                keyValue: "5769e9cc-31cf-41c7-ae6d-f1baee877217");

            migrationBuilder.RenameColumn(
                name: "TotalIncorectAnswers",
                table: "Attempts",
                newName: "TotalIncorrectAnswers");

            migrationBuilder.AddColumn<string>(
                name: "QuizName",
                table: "Attempts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AttemptQuestion",
                columns: table => new
                {
                    AttemptedQuestionsQuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttemptsAttemptId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttemptQuestion", x => new { x.AttemptedQuestionsQuestionId, x.AttemptsAttemptId });
                    table.ForeignKey(
                        name: "FK_AttemptQuestion_Attempts_AttemptsAttemptId",
                        column: x => x.AttemptsAttemptId,
                        principalTable: "Attempts",
                        principalColumn: "AttemptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttemptQuestion_Questions_AttemptedQuestionsQuestionId",
                        column: x => x.AttemptedQuestionsQuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttemptQuestion_AttemptsAttemptId",
                table: "AttemptQuestion",
                column: "AttemptsAttemptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttemptQuestion");

            migrationBuilder.DropColumn(
                name: "QuizName",
                table: "Attempts");

            migrationBuilder.RenameColumn(
                name: "TotalIncorrectAnswers",
                table: "Attempts",
                newName: "TotalIncorectAnswers");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseDescription", "CourseImage", "CourseName", "CourseUrl" },
                values: new object[,]
                {
                    { "01ccac23-bf0d-4dd2-8ef4-6da7a68d9d55", "A document that you should ideally give to each employee upon hiring. Prospective employees should read the policy, sign it, and date it before they start work.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Email And Internet Usage Policy", "https://localhost:7196/api/Document/Download?documentId=342c4724-0aeb-4d69-ba8f-12424e49274a" },
                    { "0706291e-019d-4e12-8466-2c25ccb59423", "Fake communications that appear to come froma trusted source, but these communications can put all kinds of your data at risk.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Phishing Attacks", "https://localhost:7196/api/Document/Download?documentId=15098b99-f2c0-42a9-9cd0-499a4ba0875d" },
                    { "0b5be3ac-26ff-44bc-8441-0418fda1e182", "You'll learn about mobile security vulnerabilities and threats in this in-depth exploration of mobile security in the company.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Mobile Device Security", "https://localhost:7196/api/Document/Download?documentId=44fd3336-21d9-4bf7-8b6a-c85d1a4082ef" },
                    { "223c2eb9-fac4-4d3a-9c6f-97275952fbd6", "describes measures designed to ensure the physical protection of IT assets such as facilities, equipment and other property from damage and unauthorized physical access.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Physical Security", "https://localhost:7196/api/Document/Download?documentId=f4b013a6-b2dd-415c-91f7-54c4b49f5de7" },
                    { "63348933-17e6-4973-8726-95ee3ca79af1", "Found in popular public places like airports, coffee shops, malls, restaurants, and hotels and it allows you to access the internet for free.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Public Wi-Fi", "https://localhost:7196/api/Document/Download?documentId=b97f6cf2-cf17-4abe-9b1c-c4a862701bf8" },
                    { "a216c3ad-5caf-435b-8b15-c365829d2972", "A manipulation technique that exploits human error to gain private information, access, or valuables.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Social Engineering", "https://localhost:7196/api/Document/Download?documentId=4451fdbd-d680-4633-b552-6a746aa8cc9c" },
                    { "cd9592f9-4c69-4cb2-8ed6-9c098b5da3d6", "A collection of procedures and technology designed to address external and internal threats to business security.", "https://localhost:7196/api/Document/Download?documentId=83017331-5426-47f9-ac19-31aaef08bea7", "Cloud Security", "https://localhost:7196/api/Document/Download?documentId=c723b5e9-9971-467f-ac32-88beda990cbf" }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "CourseId", "Description", "Duration", "MaximumScore", "Title", "TotalQuestions" },
                values: new object[] { "5769e9cc-31cf-41c7-ae6d-f1baee877217", "8d97ee89-cb8b-47ea-b59e-ac276866fe4e", "The quiz consists of questions carefully designed to help you self-assess your comprehension of the information presented on the topics covered in the module\nEach question in the quiz is of multiple-choice or \"true or false\" format. Read each question carefully.\nAfter responding to a question, click on the \"Next Question\" button at the bottom to go to the next question. After responding to the 10th question, click on \"Submit\" on the top of the window to submit the quiz.\nYou have 3 attempts to complete the quiz. If you fail to complete the quiz within 3 attempts your final grade will be zero.", "30", 100, "Social Engineering Quiz", 10 });
        }
    }
}
