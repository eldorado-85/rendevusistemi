using DevExpress.Web.Mvc;
using rendevusistemi.Database;
using rendevusistemi.Database.Data;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

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
                if (ModelState.IsValid)
                {
                    db.Employes.Add(emp);
                    db.SaveChanges();

                    return RedirectToAction("RegisterView");
                }
                else
                {
                    ViewBag.Message = "Doğrulama başarısız..";
                }
                return View(emp);


                //    if (ModelState.IsValid)
                //    {
                //        db.Employes.Add(emp);
                //        db.SaveChanges();
                //        return RedirectToAction("RegisterView");
                //        //doğrulama olduğu zaman yapılacak işlemler,yönlendirilecek sayfa vb.

                //    //doğrulama yapılmadığı takdirde ekrana aynı view getirilecek
                //    return View();
                //    db.Employes.Add(emp);
                //        db.SaveChanges();
                //        return RedirectToAction("RegisterView");


                //}

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
            update.Firstname = UpdEmp.Firstname;
            update.Adress = UpdEmp.Adress;
            update.Phone = UpdEmp.Phone;
            update.Description = UpdEmp.Description;
            update.IsOk = UpdEmp.IsOk;

            db.SaveChanges();
            return RedirectToAction("RegisterView");


        }


        public ActionResult RegisterDel(int id)
        {
            MyDbContext db = new MyDbContext();
            var list = db.Employes.Where(a => a.Id == id).FirstOrDefault();


            return View(list);
        }
        [HttpPost]
        public ActionResult RegisterDel(Emploies Deloper)
        {
            MyDbContext db = new MyDbContext();


            try
            {

                Emploies DelEmp = db.Employes.Where(o => o.Id == Deloper.Id).FirstOrDefault();
                db.Employes.Remove(DelEmp);
                db.SaveChanges();
                return RedirectToAction("RegisterView");
            }
            catch
            {
                return View();
            }
        }


        rendevusistemi.Database.MyDbContext db = new rendevusistemi.Database.MyDbContext();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.Employes;
            return PartialView("_GridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] rendevusistemi.Database.Data.Emploies item)
        {
            var model = db.Employes;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] rendevusistemi.Database.Data.Emploies item)
        {
            var model = db.Employes;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 Id)
        {
            var model = db.Employes;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model.ToList());
        }
    }
}