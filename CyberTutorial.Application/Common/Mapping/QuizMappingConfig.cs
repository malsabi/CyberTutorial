using Mapster;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Quizzes.Common;

namespace CyberTutorial.Application.Common.Mapping
{
    public class QuizMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Quiz, GetQuizByIdResult>()
                  .Map(dest => dest.Quiz.QuizId, src => src.QuizId)
                  .Map(dest => dest.Quiz.Title, src => src.Title)
                  .Map(dest => dest.Quiz.Description, src => src.Description)
                  .Map(dest => dest.Quiz.MaximumScore, src => src.MaximumScore)
                  .Map(dest => dest.Quiz.TotalQuestions, src => src.TotalQuestions)
                  .Map(dest => dest.Quiz.Duration, src => src.Duration)
                  .Map(dest => dest.Quiz.CourseId, src => src.CourseId)
                  .Map(dest => dest.Quiz.Questions, src => src.Questions)
                  .Map(dest => dest.Quiz.Attempts, src => src.Attempts)
                  .MaxDepth(4);

            config.NewConfig<Quiz, UpdateQuizResult>()
                  .Map(dest => dest.Quiz.QuizId, src => src.QuizId)
                  .Map(dest => dest.Quiz.Title, src => src.Title)
                  .Map(dest => dest.Quiz.Description, src => src.Description)
                  .Map(dest => dest.Quiz.MaximumScore, src => src.MaximumScore)
                  .Map(dest => dest.Quiz.TotalQuestions, src => src.TotalQuestions)
                  .Map(dest => dest.Quiz.Duration, src => src.Duration)
                  .Map(dest => dest.Quiz.CourseId, src => src.CourseId)
                  .Map(dest => dest.Quiz.Questions, src => src.Questions)
                  .Map(dest => dest.Quiz.Attempts, src => src.Attempts)
                  .MaxDepth(4);
        }
    }
}