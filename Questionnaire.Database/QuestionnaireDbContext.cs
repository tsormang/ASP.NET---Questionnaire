using Questionnaire.Entity;
using System;
using System.Data.Entity;

namespace Questionnaire.Database
{
    public class QuestionnaireDbContext:DbContext,IDisposable
    {
        public QuestionnaireDbContext():base("name=QuestionConn")
        {

        }
        public DbSet<Answer> AnswersDb { get; set; }
        public DbSet<Question> QuestionsDb { get; set; }
        public DbSet<Theme> ThemesDb { get; set; }
        public DbSet<Questionnaire_> QuestionnairesDb { get; set; }
    }
}
