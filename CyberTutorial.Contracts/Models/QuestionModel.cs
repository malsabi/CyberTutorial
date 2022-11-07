using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTutorial.Contracts.Models
{
    public class QuestionModel
    {
        public string QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<AnswerModel> Answers { get; set; }
    }
}