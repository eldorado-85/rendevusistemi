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

        public ActionResult RegisterEdit()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Entry()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
     

      
    }
}

