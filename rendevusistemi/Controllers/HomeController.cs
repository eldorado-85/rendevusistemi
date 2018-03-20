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




    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tables()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Grafikler()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

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
             var  edit = db.Employes.Where(a => a.Id == id).FirstOrDefault();

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

      

        public ActionResult TestKayit()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult TestKayit(Job myjob)
        {
            MyDbContext db = new MyDbContext();
            db.Jobs.Add(myjob);
            db.SaveChanges();
            return RedirectToAction("TestView");

          
        }

        public ActionResult TestView()
        {
            MyDbContext db = new MyDbContext();
            var list = db.Jobs.ToList();


            return View(list);
        }

        public ActionResult TestEdit(int id)
        {
            MyDbContext db = new MyDbContext();
            var list = db.Jobs.Where(a => a.Id == id).FirstOrDefault();


            return View(list);
        }
        [HttpPost]
        public ActionResult TestEdit(Job UpdateJob)
        {
            MyDbContext db = new MyDbContext();

            var update = db.Jobs.Where(a => a.Id == UpdateJob.Id).FirstOrDefault();
            update.Name = UpdateJob.Name;
            db.SaveChanges();


            return RedirectToAction("TestView");
        }

        public ActionResult Entry()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

