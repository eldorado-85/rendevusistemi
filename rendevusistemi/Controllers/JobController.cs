using rendevusistemi.Database;
using rendevusistemi.Database.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rendevusistemi.Controllers
{
    public class JobController : Controller
    {

        public ActionResult Job()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Job(Job myjob)
        {
            MyDbContext db = new MyDbContext();
            db.Jobs.Add(myjob);
            db.SaveChanges();
            return RedirectToAction("JobView");


        }

        public ActionResult JobView()
        {
            MyDbContext db = new MyDbContext();
            var list = db.Jobs.ToList();


            return View(list);
        }

        public ActionResult JobEdit(int id)
        {
            MyDbContext db = new MyDbContext();
            var list = db.Jobs.Where(a => a.Id == id).FirstOrDefault();


            return View(list);
        }
        [HttpPost]
        public ActionResult JobEdit(Job UpdateJob)
        {
            MyDbContext db = new MyDbContext();

            var update = db.Jobs.Where(a => a.Id == UpdateJob.Id).FirstOrDefault();
            update.Name = UpdateJob.Name;
            db.SaveChanges();


            return RedirectToAction("JobView");
        }
    }
}