using Questionnaire.Database;
using Questionnaire.Entity;
using Questionnaire.Entity.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Questionnaire.Services
{
    public class QuestionnaireService
    {
        //                 Get                  \\
        public List<Questionnaire_> GetQuestionnaires()
        {
            using (var db = new QuestionnaireDbContext())
            {

                List<Questionnaire_> Questionnaires = db.QuestionnairesDb.Include(x => x.Themes.Select(y => y.Questions.Select(z => z.Answers))).ToList();

                return Questionnaires;
            }
        }


        public Questionnaire_ GetQuestionnaire(int? Id)
        {
            using (var db = new QuestionnaireDbContext())
            {
                Questionnaire_ Questionnairee = db.QuestionnairesDb.Where(x => x.QuestionnaireID == Id).Include(y => y.Themes.Select(z => z.Questions.Select(za => za.Answers))).FirstOrDefault();

                return Questionnairee;
            }
        }
        public QuestionnaireThemesVM GetQuestionnairesVM()
        {
            using (var db = new QuestionnaireDbContext())
            {
                QuestionnaireThemesVM ViewModel = new QuestionnaireThemesVM();
                ViewModel.Themes = db.ThemesDb.ToList();

                return ViewModel;
            }
        }
        public QuestionnaireThemesVM GetQuestionnairesVM(int? id)
        {
            using (var db = new QuestionnaireDbContext())
            {
                QuestionnaireThemesVM ViewModel = new QuestionnaireThemesVM();
                ViewModel.Themes = db.ThemesDb.ToList();
                ViewModel.Questionnaire = db.QuestionnairesDb.Where(x=>x.QuestionnaireID==id).Include(y => y.Themes.Select(z => z.Questions.Select(za => za.Answers))).FirstOrDefault();

                return ViewModel;
            }
        }



        //             Add | Save | Create                \\

        public void CreateQuestionnaireVM(QuestionnaireThemesVM ViewModel)
        {
            using (var db = new QuestionnaireDbContext())
            {



                ViewModel.Questionnaire.Themes = db.ThemesDb.Where(x => ViewModel.CheckedThemeIDs.Contains(x.ThemeID)).Include(y => y.Questions.Select(z=>z.Answers)).ToList();
                db.QuestionnairesDb.Add(ViewModel.Questionnaire);
                db.SaveChanges();
            }
        }



        //                      Edit                     \\
        public void EditQuestionnaire(QuestionnaireThemesVM ViewModel)
        {
            using (var db = new QuestionnaireDbContext())
            {
                Questionnaire_ TempQuestionnaire = db.QuestionnairesDb.Where(x => x.QuestionnaireID== ViewModel.Questionnaire.QuestionnaireID).Include(y => y.Themes.Select(z => z.Questions.Select(za => za.Answers))).FirstOrDefault();

                TempQuestionnaire.Themes = db.ThemesDb.Where(x => ViewModel.CheckedThemeIDs.Contains(x.ThemeID)).Include(y => y.Questions.Select(z=>z.Answers)).ToList();


                db.Entry(TempQuestionnaire).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        //////                      Delete                     \\
        ////public void DeleteQuestion(int Id)
        ////{
        ////    using (var db = new QuestionnaireDbContext())
        ////    {
        ////        Question question = db.QuestionsDb.Find(Id);
        ////        db.QuestionsDb.Remove(question);
        ////        db.SaveChanges();
        ////    }
        ////}
    }
        }






