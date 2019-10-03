using Questionnaire.Database;
using Questionnaire.Entity;
using Questionnaire.Entity.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Questionnaire.Services
{
    public class ThemeService
    {

            //                 Get                  \\
            public List<Theme> GetThemes()
            {
                using (var db = new QuestionnaireDbContext())
                {
                List<Theme> themes = db.ThemesDb.Include(x => x.Questions.Select(y=>y.Answers)).ToList();

                return db.ThemesDb.ToList();
                }
            }


        public Theme GetTheme(int? Id)
        {
            using (var db = new QuestionnaireDbContext())
            {
                Theme theme = db.ThemesDb.Include(x=>x.Questions).Where(x=>x.ThemeID==Id).FirstOrDefault();
                Debug.WriteLine("AnswerCount:" + theme.Questions.Count);
                return theme;
            }
        }
        public ThemeListQuestionsVM GetThemeVM(int? Id)
        {
            using (var db = new QuestionnaireDbContext())
            {
                ThemeListQuestionsVM ViewModel = new ThemeListQuestionsVM();
                ViewModel.Theme = db.ThemesDb.Include(x => x.Questions).Where(x => x.ThemeID == Id).FirstOrDefault();
               
                return ViewModel;
            }
        }

        public ThemeListQuestionsVM GetThemesVM()
        {
            using (var db = new QuestionnaireDbContext())
            {
                ThemeListQuestionsVM ViewModel = new ThemeListQuestionsVM();

                //Get All Questions
                var questionlist = db.QuestionsDb.Include(y => y.Answers).ToList();
                ViewModel.Questions = questionlist;

                Debug.WriteLine("QuestionCount           :" + questionlist.Count);
                Debug.WriteLine("QuestionCountViewModel  :" + ViewModel.Questions.Count);
                return ViewModel;
            }
        }


        ////             Add | Save | Create                \\
        public void CreateTheme(ThemeListQuestionsVM ViewModel)
        {
            using (var db = new QuestionnaireDbContext())
            {



                ViewModel.Theme.Questions = db.QuestionsDb.Where(question => ViewModel.CheckedQuestionIDs.Contains(question.QuestionID)).Include(y => y.Answers).ToList();
                db.ThemesDb.Add(ViewModel.Theme);
                db.SaveChanges();
            }
        }



        //                      Edit                     \\
        public void EditQuestion(ThemeListQuestionsVM ViewModel)
        {
            using (var db = new QuestionnaireDbContext())
            {
                Theme TempTheme = db.ThemesDb.Where(x => x.ThemeID == ViewModel.Theme.ThemeID).Include(y => y.Questions).FirstOrDefault();
                TempTheme.Questions = db.QuestionsDb.Where(x => ViewModel.CheckedQuestionIDs.Contains(x.QuestionID)).Include(y => y.Answers).ToList();
                
                
                db.Entry(TempTheme).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        ////                      Delete                     \\
        //public void DeleteQuestion(int Id)
        //{
        //    using (var db = new QuestionnaireDbContext())
        //    {
        //        Question question = db.QuestionsDb.Find(Id);
        //        db.QuestionsDb.Remove(question);
        //        db.SaveChanges();
        //    }
        //}
    }
    }
