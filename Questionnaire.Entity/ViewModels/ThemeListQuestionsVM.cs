using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Entity.ViewModels
{
    public class ThemeListQuestionsVM
    {
        public Theme Theme { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<int> CheckedQuestionIDs { get; set ;} = new List<int>();
    }
}
