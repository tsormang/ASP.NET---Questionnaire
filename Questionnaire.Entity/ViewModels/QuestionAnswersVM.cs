using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Entity.ViewModels
{
    public class QuestionAnswersVM
    {
        public Question Question { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
        public string CorrectAnswerID { get; set; } 


    }
}
