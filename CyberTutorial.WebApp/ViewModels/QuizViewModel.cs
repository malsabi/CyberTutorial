using ErrorOr;
using CyberTutorial.WebApp.Models;
using CyberTutorial.Contracts.Models;
using CyberTutorial.Contracts.Responses.Quiz;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.ViewModels
{
    public class QuizViewModel
    {
        private readonly IQuizService quizService;
        private readonly AttemptViewModel attemptViewModel;
        private readonly EmployeeViewModel employeeViewModel;

        public QuizViewModel(IQuizService quizService, AttemptViewModel attemptViewModel,  EmployeeViewModel employeeViewModel)
        {
            this.quizService = quizService;
            this.attemptViewModel = attemptViewModel;
            this.employeeViewModel = employeeViewModel;
        }

        public async Task<ControllerResultModel> GetQuizzesAsync()
        {
            ControllerResultModel result;
            ControllerResultModel employeeResult = await employeeViewModel.GetEmployeeAsync();
            if (!employeeResult.IsSuccess)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = employeeResult.Message,
                    Data = employeeResult.Data
                };
            }
            else
            {
                EmployeeModel employee = (EmployeeModel)employeeResult.Data;
                quizService.Token = employee.Session.Token;
                ErrorOr<GetQuizzesResponse> response = await quizService.GetQuizzesAsync();
                if (response.IsError)
                {
                    result = new ControllerResultModel()
                    {
                        IsSuccess = false,
                        Message = response.FirstError.Description,
                        Data = response
                    };
                }
                else
                {
                    List<QuizModel> quizzes = (List<QuizModel>)response.Value.Quizzes;
                    result = new ControllerResultModel()
                    {
                        IsSuccess = true,
                        Message = "Quizzes retrieved successfully.",
                        Data = quizzes
                    };
                }
            }
            return result;
        }

        public async Task<ControllerResultModel> GetQuizMarksAsync(string quizId)
        {
            ControllerResultModel result;
            ControllerResultModel employeeResult = await employeeViewModel.GetEmployeeAsync();
            if (!employeeResult.IsSuccess)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = employeeResult.Message,
                    Data = employeeResult.Data
                };
            }
            else
            {
                EmployeeModel employee = (EmployeeModel)employeeResult.Data;
                List<AttemptModel> attempts = employee.Attempts.Where(a => a.QuizId == quizId).ToList();
                if (attempts == null)
                {
                    result = new ControllerResultModel()
                    {
                        IsSuccess = false,
                        Message = "Failed to load employee attempts.",
                        Data = null
                    };
                }
                else
                {
                    attempts = attempts.OrderBy(x =>
                    {
                        DateTime dt;
                        DateTime.TryParse(x.StartedAt, out dt);
                        return dt;
                    }).ToList();
                    
                    result = new ControllerResultModel()
                    {
                        IsSuccess = true,
                        Message = attempts.Count > 0 ? "All Quiz marks retrieved successfully." : "You have not attempted this quiz yet.",
                        Data = attempts
                    };
                }
            }
            return result;
        }

        public async Task<ControllerResultModel> CanAttemptQuizAsync(string quizId)
        {
            ControllerResultModel result;
            ControllerResultModel employeeResult = await employeeViewModel.GetEmployeeAsync();
            if (!employeeResult.IsSuccess)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = employeeResult.Message,
                    Data = employeeResult.Data
                };
            }
            else
            {
                EmployeeModel employee = (EmployeeModel)employeeResult.Data;
                int attemptsCount = employee.Attempts.Where(a => a.QuizId == quizId).ToList().Count;
                if (attemptsCount >= 300)
                {
                    result = new ControllerResultModel()
                    {
                        IsSuccess = true,
                        Message = "You have already attempted this quiz 3 times.",
                        Data = attemptsCount
                    };
                }
                else
                {
                    result = new ControllerResultModel()
                    {
                        IsSuccess = true,
                        Message = "You can attempt this quiz.",
                        Data = attemptsCount
                    };
                }
            }
            return result;
        }
        
        public async Task<ControllerResultModel> StartQuizAsync(string quizId)
        {
            ControllerResultModel result;
            ControllerResultModel employeeResult = await employeeViewModel.GetEmployeeAsync();
            if (!employeeResult.IsSuccess)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = employeeResult.Message,
                    Data = employeeResult.Data
                };
            }
            else
            {
                EmployeeModel employee = (EmployeeModel)employeeResult.Data;
                quizService.Token = employee.Session.Token;
                ErrorOr<GetQuizByIdResponse> response = await quizService.GetQuizAsync(quizId);
                if (response.IsError)
                {
                    result = new ControllerResultModel()
                    {
                        IsSuccess = false,
                        Message = response.FirstError.Description,
                        Data = response
                    };
                }
                else
                {
                    QuizModel quiz = (QuizModel)response.Value.Quiz;

                    AttemptModel attempt = new AttemptModel()
                    {
                        EmployeeId = employee.EmployeeId,
                        QuizId = quiz.QuizId,
                        QuizName = quiz.Title,
                        StartedAt = DateTime.Now.ToString(),
                        CompletedAt = DateTime.MinValue.ToString(),
                        IsStarted = true,
                        IsCompleted = false,
                        Score = 0,
                        TotalCorrectAnswers = 0,
                        TotalIncorrectAnswers = 0,
                        AttemptedQuestions = new List<QuestionModel>()
                    };

                    ControllerResultModel addAttemptResult = await attemptViewModel.AddAttemptAsync(attempt);
                    
                    if (!addAttemptResult.IsSuccess)
                    {
                        result = addAttemptResult;
                    }
                    else
                    {
                        employee.EmployeeDashboard.TotalQuizzes += 1;
                        employee.EmployeeDashboard.TotalQuizzesLastModified = DateTime.Now.ToString();
                        ControllerResultModel updateEmployeeResult = await employeeViewModel.UpdateEmplyeeDashboardAsync(employee.EmployeeDashboard);

                        if (!updateEmployeeResult.IsSuccess)
                        {
                            result = updateEmployeeResult;
                        }
                        else
                        {
                            result = new ControllerResultModel()
                            {
                                IsSuccess = true,
                                Message = "Quiz started successfully.",
                                Data = quiz
                            };
                        }
                    }
                }
            }
            return result;
        }

        public async Task<ControllerResultModel> GetAttemptedQuizzesAsync()
        {
            ControllerResultModel result;
            ControllerResultModel employeeResult = await employeeViewModel.GetEmployeeAsync();
            if (!employeeResult.IsSuccess)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = employeeResult.Message,
                    Data = employeeResult.Data
                };
            }
            else
            {
                EmployeeModel employee = (EmployeeModel)employeeResult.Data;
                List<AttemptModel> attempts = (List<AttemptModel>)employee.Attempts;

                attempts = attempts.OrderBy(x =>
                {
                    DateTime dt;
                    DateTime.TryParse(x.StartedAt, out dt);
                    return dt;
                }).ToList();

                result = new ControllerResultModel()
                {
                    IsSuccess = true,
                    Message = attempts.Count > 0 ? "All attempted quizzes retrieved successfully." : "You have not attempted any quiz yet.",
                    Data = attempts
                };
            }
            return result;
        }
    }
}