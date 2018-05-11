using DevExpress.Web.Mvc;
using rendevusistemi.Database;
using rendevusistemi.Database.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        public ActionResult Entry()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            //BURASI URL KONTROLÜ İÇİN
            //Session["username"] = @ViewBag.Name;
            //return Redirect("/User/Home");
            return Redirect("/Index/Home");



        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User model, string returnurl)
        {
            if (ModelState.IsValid)
            { MyDbContext db = new MyDbContext();

                
               

                var kullanici = db.Users.Where(ww => ww.UserName == model.UserName && ww.Password == model.Password);
                //RepositoryPortal<AdminUser> rptryadmn = new RepositoryPortal<AdminUser>();
                //Aşağıdaki if komutu gönderilen mail ve şifre doğrultusunda kullanıcı kontrolu yapar. Eğer kullanıcı var ise login olur.
                if (kullanici.Count()> 0)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı!");
                }
            }
            return View(model);
        }

        public ActionResult Giris()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




    }

}

