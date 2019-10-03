using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Questionnaire.Database;
using Questionnaire.Entity;
using Questionnaire.Entity.ViewModels;
using Questionnaire.Services;

namespace Questionnaire.Web.Controllers
{
    public class QuestionController : Controller
    {
        QuestionService QuestionServ = new QuestionService();
        private QuestionnaireDbContext db = new QuestionnaireDbContext();

        // GET: Question
        public ActionResult Index()
        {
            return View(QuestionServ.GetQuestions());
        }

        // GET: Question/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = QuestionServ.GetQuestion(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( QuestionAnswersVM Obj)
        {
            if (ModelState.IsValid)
            {
                QuestionServ.CreateQuestion(Obj);
                return RedirectToAction("Index");
            }

            return View(Obj.Question);
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");

                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswersVM question = new QuestionAnswersVM();
            question =   QuestionServ.GetQuestionViewModel(id);
            Debug.WriteLine("AnswerCount:" + question.Question.Answers.Count);

            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Question question, List<string> lista,string correctPossition)
        {
            if (ModelState.IsValid)
            {
                QuestionServ.EditQuestion(question,lista,correctPossition);

                return RedirectToAction("Index");
            }
            return View(question);
        }



        // GET: Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = QuestionServ.GetQuestion(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionServ.DeleteQuestion(id);            
            return RedirectToAction("Index");
        }
    }
}
