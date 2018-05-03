using rendevusistemi.Database;
using rendevusistemi.Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rendevusistemi.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult User()
        {


            return View();
        }

        [HttpPost]
        public ActionResult User(Login usr)
        {

            using (MyDbContext db = new MyDbContext())
            {
                if (ModelState.IsValid)
                {
                    db.Logins.Add(usr);
                    db.SaveChanges();

                    return RedirectToAction("UserView");
                }
                else
                {
                    ViewBag.Message = "Doğrulama başarısız..";
                }
                return View(usr);


           
            }
        }
        public ActionResult UserView()
        {
            MyDbContext db = new MyDbContext();
            List<Login> usr = db.Logins.ToList();


            return View(usr);
        }

        public ActionResult UserEdit(int id)
        {
            MyDbContext db = new MyDbContext();
            var edit = db.Logins.Where(a => a.Id == id).FirstOrDefault();

            return View(edit);
        }
        [HttpPost]
        public ActionResult UserEdit(Login UpdUsr)
        {
            MyDbContext db = new MyDbContext();
            var update = db.Logins.Where(a => a.Id == UpdUsr.Id).FirstOrDefault();
            update.Name = UpdUsr.Name;
            update.Password = UpdUsr.Password;
     

            db.SaveChanges();
            return RedirectToAction("UserView");


        }


        public ActionResult UserDel(int id)
        {
            MyDbContext db = new MyDbContext();
            var list = db.Logins.Where(a => a.Id == id).FirstOrDefault();


            return View(list);
        }
        [HttpPost]
        public ActionResult UserDel(Login DelUser)
        {
            MyDbContext db = new MyDbContext();


            try
            {

                Login DelUsr = db.Logins.Where(o => o.Id == DelUser.Id).FirstOrDefault();
                db.Logins.Remove(DelUsr);
                db.SaveChanges();
                return RedirectToAction("UserView");
            }
            catch
            {
                return View();
            }
        }

    }
}
