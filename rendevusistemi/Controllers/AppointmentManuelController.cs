using DevExpress.Web.Mvc;
using rendevusistemi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rendevusistemi.Controllers
{
    public class AppointmentManuelController : Controller
    {
        public ActionResult AppointmentManuView()
        {
            MyDbContext db = new MyDbContext();
            var list = db.Appointmenties.ToList();


            return View(list);
        }

        public ActionResult AppointmentManuEdit(int id)
        {
            MyDbContext db = new MyDbContext();
            var list = db.Jobs.Where(a => a.Id == id).FirstOrDefault();


            return View(list);
        }
        //    [HttpPost]
        //    public ActionResult AppointmentManuEdit(Appointment UpdateJob)
        //    {
        //        MyDbContext db = new MyDbContext();

        //        var update = db.Jobs.Where(a => a.Id == UpdateJob.Id).FirstOrDefault();
        //        update.Name = UpdateJob.Name;
        //        db.SaveChanges();


        //        return RedirectToAction("AppointmentManuView");
        //    }

        rendevusistemi.Database.MyDbContext db = new rendevusistemi.Database.MyDbContext();

        [ValidateInput(false)]
        public ActionResult DataViewPartial()
        {
            var model = db.Appointmenties;
            return PartialView("_DataViewPartial", model.ToList());
        }

        rendevusistemi.Database.MyDbContext db1 = new rendevusistemi.Database.MyDbContext();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db1.Appointmenties;
            return PartialView("_GridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] rendevusistemi.Database.Data.Appointments item)
        {
            var model = db1.Appointmenties;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db1.SaveChanges();
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
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] rendevusistemi.Database.Data.Appointments item)
        {
            var model = db1.Appointmenties;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db1.SaveChanges();
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
            var model = db1.Appointmenties;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
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