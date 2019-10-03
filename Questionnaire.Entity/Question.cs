using System.Collections.Generic;

namespace Questionnaire.Entity
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionValue { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Theme> Themes { get; set; }
    }
}
