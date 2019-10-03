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
    public class ThemeController : Controller
    {
        private QuestionnaireDbContext db = new QuestionnaireDbContext();
        private ThemeService ThemeServ = new ThemeService();
        private QuestionService QuestionServ = new QuestionService();

        // GET: Theme
        public ActionResult Index()
        {
            return View(db.ThemesDb.ToList());
        }

        // GET: Theme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.ThemesDb.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        // GET: Theme/Create
        public ActionResult Create()
        {
            return View(ThemeServ.GetThemesVM());
        }

        // POST: Theme/Create
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThemeListQuestionsVM ViewModel)
        {
            //ModelState.Clear();
            if (ModelState.IsValid)
            {
                ThemeServ.CreateTheme(ViewModel);
                return RedirectToAction("Index");
            }

            return View(ViewModel);
        }

        // GET: Theme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThemeListQuestionsVM ViewModel = ThemeServ.GetThemeVM(id);
            ViewModel.Questions = QuestionServ.GetQuestions();
            if (ViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ViewModel);
        }

        // POST: Theme/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ThemeListQuestionsVM ViewModel)
        {
            if (ModelState.IsValid)
            {
                ThemeServ.EditQuestion(ViewModel);
                return RedirectToAction("Index");
            }
            return View(ViewModel);
        }

        // GET: Theme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.ThemesDb.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        // POST: Theme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theme theme = db.ThemesDb.Find(id);
            db.ThemesDb.Remove(theme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
