using System.Collections.Generic;

namespace Questionnaire.Entity.ViewModels
{
    public class QuestionnaireThemesVM
    {
        public Questionnaire_ Questionnaire { get; set; }
        public List<Theme> Themes { get; set; } = new List<Theme>();
        public List<int> CheckedThemeIDs { get; set; } = new List<int>();
    }
}
