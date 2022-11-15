using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Infrastructure.Persistence.Seeding
{
    public  class QuizSeeding
    {
        public static string Description = 
            "The quiz consists of questions carefully designed to help you self-assess your comprehension of the information presented on the topics covered in the module" +
            "\n" +
            "Each question in the quiz is of multiple-choice or \"true or false\" format. Read each question carefully." +
            "\n" +
            "After responding to a question, click on the \"Next Question\" button at the bottom to go to the next question. After responding to the 10th question, click on \"Submit\" on the top of the window to submit the quiz." +
            "\n" +
            "You have 3 attempts to complete the quiz. If you fail to complete the quiz within 3 attempts your final grade will be zero.";

        public static List<Quiz> Quizzes()
        {
            return new List<Quiz>()
            {
                //Social Engineering Quiz
                new Quiz()
                {
                    QuizId = Guid.NewGuid().ToString(),
                    Title = "Social Engineering Quiz",
                    Description = Description,
                    MaximumScore = 100,
                    TotalQuestions = 10,
                    Duration = "30",
                    CourseId = "a7794720-fb6b-4b7f-b36f-54cde2c58dfc",
                    Questions = new List<Question>()
                    {
                        new Question()
                        {
                            QuestionId = Guid.NewGuid().ToString(),
                            Title = "Multiple Choice Question",
                            Description = "Define the term social engineering?",
                            Answers = new List<Answer>()
                            {
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "The use of persuasion or influence to deceive personnel into divulging confidential information or allowing the adversary to perform unauthorized actions. It relies on human weaknesses such as the willingness to help and unwillingness to question authority.",
                                    IsCorrect = true
                                },
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "There are two main subtypes of social engineering: computer-based (pop-ups, mail attachments, IM, faked web sites), which depends on software, and human-based (impersonation, dumpster diving, tailgating), which depends on human interaction.",
                                    IsCorrect = false
                                },
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "Social engineering is a form of attack that relies on human interaction",
                                    IsCorrect = false
                                },
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "Information gathering -> Development of a relationship -> Exploitation of relationship -> Execution to achieve objective.",
                                    IsCorrect = false
                                }
                            }
                        }, //Question 1
                        new Question()
                        {
                            QuestionId = Guid.NewGuid().ToString(),
                            Title = "Multiple Choice Question",
                            Description = "What are the types of social engineering?",
                            Answers = new List<Answer>()
                            {
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "There are two main subtypes of social engineering: computer-based (pop-ups, mail attachments, IM, faked web sites), which depends on software, and human-based (impersonation, dumpster diving, tailgating), which depends on human interaction.",
                                    IsCorrect = true
                                },
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "The use of persuasion or influence to deceive personnel into divulging confidential information or allowing the adversary to perform unauthorized actions. It relies on human weaknesses such as the willingness to help and unwillingness to question authority.",
                                    IsCorrect = false
                                },
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "Social engineering is a form of attack that relies on human interaction.",
                                    IsCorrect = false
                                },
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "Information gathering -> Development of a relationship -> Exploitation of relationship -> Execution to achieve objective.",
                                    IsCorrect = false
                                }
                            }
                        }, //Question 2
                        new Question()
                        {
                            QuestionId = Guid.NewGuid().ToString(),
                            Title = "True or False Question",
                            Description = "In computer security, the term \"Dumpster diving\" is used to describe a practice of sifting through trash for discarded documents containing sensitive data. Found documents containing names and surnames of the employees along with the information about positions held in the company and other data can be used to facilitate social engineering attacks. Having the documents shredded or incinerated before disposal makes dumpster diving less effective and mitigates the risk of social engineering attacks.",
                            Answers = new List<Answer>()
                            {
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "True",
                                    IsCorrect = true
                                },
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "False",
                                    IsCorrect = false
                                }
                            }
                        }, //Question 3
                        new Question()
                        {
                            QuestionId = Guid.NewGuid().ToString(),
                            Title = "True or False Question",
                            Description = "Privacy filter (a.k.a. privacy screen) is a protective overlay placed on the computer screen that narrows the viewing angle, so the screen content is only visible directly in front of the monitor and cannot be seen by others nearby. Privacy filter is one of the countermeasures against shoulder surfing.",
                            Answers = new List<Answer>()
                            {
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "True",
                                    IsCorrect = true
                                },
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "False",
                                    IsCorrect = false
                                }
                            }
                        }, //Question 4
                        new Question()
                        {
                            QuestionId = Guid.NewGuid().ToString(),
                            Title = "Multiple Choice Question",
                            Description = "Which social engineering attack relies on identity theft?",
                            Answers = new List<Answer>()
                            {
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "Impersonation",
                                    IsCorrect = true
                                },
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "Tailgating",
                                    IsCorrect = false
                                },
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "Shoulder surfing",
                                    IsCorrect = false
                                },
                                new Answer()
                                {
                                    AnswerId = Guid.NewGuid().ToString(),
                                    AnswerText = "Dumpster diving",
                                    IsCorrect = false
                                }
                            }
                        }, //Question 5
                    }
                }
            };
        }
    }
}