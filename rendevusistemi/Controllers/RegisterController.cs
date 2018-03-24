using rendevusistemi.Database;
using rendevusistemi.Database.Data;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rendevusistemi.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(Emploies emp)
        {

            using (MyDbContext db = new MyDbContext())
            {

                db.Employes.Add(emp);
                db.SaveChanges();
                return RedirectToAction("RegisterView");
            }


        }
        public ActionResult RegisterView()
        {
            MyDbContext db = new MyDbContext();
            List<Emploies> emp = db.Employes.ToList();


            return View(emp);
        }

        public ActionResult RegisterEdit(int id)
        {
            MyDbContext db = new MyDbContext();
            var edit = db.Employes.Where(a => a.Id == id).FirstOrDefault();

            return View(edit);
        }
        [HttpPost]
        public ActionResult RegisterEdit(Emploies UpdEmp)
        {
            MyDbContext db = new MyDbContext();
            var update = db.Employes.Where(a => a.Id == UpdEmp.Id).FirstOrDefault();
            update.Lastname = UpdEmp.Lastname;
            update.Firstname = UpdEmp.Lastname;
            update.Adress = UpdEmp.Adress;
            update.Number = UpdEmp.Number;
            db.SaveChanges();
            return RedirectToAction("RegisterView");
        }

    }
}