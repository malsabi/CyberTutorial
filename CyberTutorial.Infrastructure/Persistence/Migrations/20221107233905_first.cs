using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberTutorial.Infrastructure.Persistence.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerEmiratesId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentSize = table.Column<long>(type: "bigint", nullable: false),
                    DocumentExtension = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "CompanySessions",
                columns: table => new
                {
                    CompanySessionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySessions", x => x.CompanySessionId);
                    table.ForeignKey(
                        name: "FK_CompanySessions_Companies_CompanySessionId",
                        column: x => x.CompanySessionId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QuizId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximumScore = table.Column<int>(type: "int", nullable: false),
                    TotalQuestions = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizId);
                    table.ForeignKey(
                        name: "FK_Quizzes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerQuestion",
                columns: table => new
                {
                    AnswersAnswerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionsQuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuestion", x => new { x.AnswersAnswerId, x.QuestionsQuestionId });
                    table.ForeignKey(
                        name: "FK_AnswerQuestion_Answers_AnswersAnswerId",
                        column: x => x.AnswersAnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerQuestion_Questions_QuestionsQuestionId",
                        column: x => x.QuestionsQuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseEmployee",
                columns: table => new
                {
                    CoursesCourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeesEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEmployee", x => new { x.CoursesCourseId, x.EmployeesEmployeeId });
                    table.ForeignKey(
                        name: "FK_CourseEmployee_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEmployee_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDashboards",
                columns: table => new
                {
                    EmployeeDashboardId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalCourses = table.Column<int>(type: "int", nullable: false),
                    TotalCoursesLastModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalQuizzes = table.Column<int>(type: "int", nullable: false),
                    TotalQuizzesLastModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPassed = table.Column<int>(type: "int", nullable: false),
                    TotalPassedLastModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalFailed = table.Column<int>(type: "int", nullable: false),
                    TotalFailedLastModified = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDashboards", x => x.EmployeeDashboardId);
                    table.ForeignKey(
                        name: "FK_EmployeeDashboards_Employees_EmployeeDashboardId",
                        column: x => x.EmployeeDashboardId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSessions",
                columns: table => new
                {
                    EmployeeSessionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSessions", x => x.EmployeeSessionId);
                    table.ForeignKey(
                        name: "FK_EmployeeSessions_Employees_EmployeeSessionId",
                        column: x => x.EmployeeSessionId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopEmployees",
                columns: table => new
                {
                    TopEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalQuizzes = table.Column<int>(type: "int", nullable: false),
                    AverageScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopEmployees", x => x.TopEmployeeId);
                    table.ForeignKey(
                        name: "FK_TopEmployees_Employees_TopEmployeeId",
                        column: x => x.TopEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attempts",
                columns: table => new
                {
                    AttemptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuizId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsStarted = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    TotalCorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    TotalIncorectAnswers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attempts", x => x.AttemptId);
                    table.ForeignKey(
                        name: "FK_Attempts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attempts_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionQuiz",
                columns: table => new
                {
                    QuestionsQuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuizzesQuizId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionQuiz", x => new { x.QuestionsQuestionId, x.QuizzesQuizId });
                    table.ForeignKey(
                        name: "FK_QuestionQuiz_Questions_QuestionsQuestionId",
                        column: x => x.QuestionsQuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionQuiz_Quizzes_QuizzesQuizId",
                        column: x => x.QuizzesQuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestion_QuestionsQuestionId",
                table: "AnswerQuestion",
                column: "QuestionsQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Attempts_EmployeeId",
                table: "Attempts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attempts_QuizId",
                table: "Attempts",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEmployee_EmployeesEmployeeId",
                table: "CourseEmployee",
                column: "EmployeesEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionQuiz_QuizzesQuizId",
                table: "QuestionQuiz",
                column: "QuizzesQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_CourseId",
                table: "Quizzes",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "AnswerQuestion");

            migrationBuilder.DropTable(
                name: "Attempts");

            migrationBuilder.DropTable(
                name: "CompanySessions");

            migrationBuilder.DropTable(
                name: "CourseEmployee");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "EmployeeDashboards");

            migrationBuilder.DropTable(
                name: "EmployeeSessions");

            migrationBuilder.DropTable(
                name: "QuestionQuiz");

            migrationBuilder.DropTable(
                name: "TopEmployees");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
