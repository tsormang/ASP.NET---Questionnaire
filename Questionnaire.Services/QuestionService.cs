using Questionnaire.Database;
using Questionnaire.Entity;
using Questionnaire.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Services
{
    public class QuestionService
    {

        //                 Get                  \\
        public List<Question> GetQuestions()
        {
            using (var db = new QuestionnaireDbContext())
            {
                return db.QuestionsDb.ToList();
            }
        }


        public Question GetQuestion(int? Id)
        {
            using (var db = new QuestionnaireDbContext())
            {
                var questions = db.QuestionsDb.Where(x => x.QuestionID == Id).Include(y => y.Answers).ToList();
                Debug.WriteLine("AnswerCount:" + questions.FirstOrDefault().Answers.Count);
                return questions.FirstOrDefault();
            }
        }
        public QuestionAnswersVM GetQuestionViewModel(int? Id)
        {
            using (var db = new QuestionnaireDbContext())
            {
                QuestionAnswersVM ViewModel = new QuestionAnswersVM();
                Question questions = db.QuestionsDb.Where(x => x.QuestionID == Id).Include(y => y.Answers).FirstOrDefault();

                ViewModel.Question = questions;

                Debug.WriteLine("AnswerCount           :" + questions.Answers.Count);
                Debug.WriteLine("AnswerCountViewModel  :" + ViewModel.Question.Answers.Count);
                return ViewModel;
            }
        }


        //             Add | Save | Create                \\
        public void CreateQuestion(Question question)
        {
            using (var db = new QuestionnaireDbContext())
            {
                db.QuestionsDb.Add(question);
                db.SaveChanges();
            }
        }
        public void CreateQuestion(QuestionAnswersVM ViewModel)
        {
            using (var db = new QuestionnaireDbContext())
            {
                for (int i = 0; i < ViewModel.Answers.Count(); i++)
                {
                    if (ViewModel.CorrectAnswerID == "{ i = " + i + " }")
                    {
                        db.AnswersDb.Add(new Answer { AnswerValue = ViewModel.Answers[i], IsCorrect = true });
                    }
                    else
                    {
                        db.AnswersDb.Add(new Answer { AnswerValue = ViewModel.Answers[i], IsCorrect = false });

                    }
                }
                db.QuestionsDb.Add(ViewModel.Question);
                db.SaveChanges();
            }
        }



        //                      Edit                     \\
        public void EditQuestion(Question question, List<string> lista, string CorrectAnswerPoss)
        {
            using (var db = new QuestionnaireDbContext())
            {
                Question TempQuestion = db.QuestionsDb.Where(x => x.QuestionID == question.QuestionID).Include(y => y.Answers).FirstOrDefault();

                for (int i = 0; i < TempQuestion.Answers.Count; i++)
                {
                    TempQuestion.Answers.ElementAt(i).IsCorrect = false;

                    TempQuestion.Answers.ElementAt(i).AnswerValue = lista[i];
                    if (CorrectAnswerPoss == i.ToString())
                        TempQuestion.Answers.ElementAt(i).IsCorrect = true;



                }
               // Debug.WriteLine("AnswerCount:" + TempQuestion.Answers.Count);
                db.Entry(TempQuestion).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        //                      Delete                     \\
        public void DeleteQuestion(int Id)
        {
            using (var db = new QuestionnaireDbContext())
            {
                Question question = db.QuestionsDb.Find(Id);
                db.QuestionsDb.Remove(question);
                db.SaveChanges();
            }
        }
    }
}
