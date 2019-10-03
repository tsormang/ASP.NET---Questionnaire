using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Entity
{
    public class Questionnaire_
    {
        [Key]
        public int QuestionnaireID { get; set; }
        public string Title { get; set; }
        public ICollection<Theme> Themes { get; set; }
    }
}
