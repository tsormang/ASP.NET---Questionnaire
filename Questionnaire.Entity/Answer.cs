using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Entity
{
     public class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerValue { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }


    }
}
