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
        public ActionResult User(User usr)
        {

            using (MyDbContext db = new MyDbContext())
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(usr);
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
            List<User> usr = db.Users.ToList();


            return View(usr);
        }

        public ActionResult UserEdit(int id)
        {
            MyDbContext db = new MyDbContext();
            var edit = db.Users.Where(a => a.Id == id).FirstOrDefault();

            return View(edit);
        }
        [HttpPost]
        public ActionResult UserEdit(User UpdUsr)
        {
            MyDbContext db = new MyDbContext();
            var update = db.Users.Where(a => a.Id == UpdUsr.Id).FirstOrDefault();
            update.UserName = UpdUsr.UserName;
            update.FirstName = UpdUsr.FirstName;
            update.LastName = UpdUsr.LastName;
            update.Password = UpdUsr.Password;
     

            db.SaveChanges();
            return RedirectToAction("UserView");


        }


        public ActionResult UserDel(int id)
        {
            MyDbContext db = new MyDbContext();
            var list = db.Users.Where(a => a.Id == id).FirstOrDefault();


            return View(list);
        }
        [HttpPost]
        public ActionResult UserDel(User DelUser)
        {
            MyDbContext db = new MyDbContext();


            try
            {

                User DelUsr = db.Users.Where(o => o.Id == DelUser.Id).FirstOrDefault();
                db.Users.Remove(DelUsr);
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
