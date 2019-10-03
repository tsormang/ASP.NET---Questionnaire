using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Entity
{
    public class Theme
    {
        public int ThemeID { get; set; }
        
        public string Title { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Questionnaire_> Questionnaires { get; set; }
    }
}
