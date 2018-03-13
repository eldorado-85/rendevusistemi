using rendevusistemi.Database;
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