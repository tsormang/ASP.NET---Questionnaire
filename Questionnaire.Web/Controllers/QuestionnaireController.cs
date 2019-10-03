using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    public class QuestionnaireController : Controller
    {
        private QuestionnaireDbContext db = new QuestionnaireDbContext();
        private QuestionnaireService QuestionnaireServ = new QuestionnaireService();

        // GET: Questionnaire
        public ActionResult Index()
        {
            return View(QuestionnaireServ.GetQuestionnaires());
        }

        // GET: Questionnaire/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionnaire_ questionnaire = QuestionnaireServ.GetQuestionnaire(id);
            if (questionnaire == null)
            {
                return HttpNotFound();
            }
            return View(questionnaire);
        }

        // GET: Questionnaire/Create
        public ActionResult Create()
        {
            QuestionnaireThemesVM ViewModel = QuestionnaireServ.GetQuestionnairesVM();
            return View(ViewModel);
        }

        // POST: Questionnaire/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionnaireThemesVM ViewModel)
        {
            if (ModelState.IsValid)
            {
                QuestionnaireServ.CreateQuestionnaireVM(ViewModel);
                return RedirectToAction("Index");
            }

            return View(ViewModel);
        }

        // GET: Questionnaire/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionnaireThemesVM ViewModel = QuestionnaireServ.GetQuestionnairesVM(id);
            if (ViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ViewModel);
        }

        // POST: Questionnaire/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionnaireThemesVM ViewModel)
        {
            if (ModelState.IsValid)
            {
                QuestionnaireServ.EditQuestionnaire(ViewModel);
                return RedirectToAction("Index");
            }
            return View(ViewModel);
        }

        // GET: Questionnaire/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionnaire_ questionnaire_ = db.QuestionnairesDb.Find(id);
            if (questionnaire_ == null)
            {
                return HttpNotFound();
            }
            return View(questionnaire_);
        }

        // POST: Questionnaire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questionnaire_ questionnaire_ = db.QuestionnairesDb.Find(id);
            db.QuestionnairesDb.Remove(questionnaire_);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
