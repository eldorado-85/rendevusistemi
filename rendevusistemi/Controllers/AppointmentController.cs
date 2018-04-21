using DevExpress.Web.Mvc;
using rendevusistemi.Database;
using rendevusistemi.Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rendevusistemi.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Appointment()
        {
            return View();
        }

        public ActionResult AppointmentView()
        {
            MyDbContext db = new MyDbContext();
            var list = db.Appointmenties.ToList();


            return View(list);
        }

        public ActionResult AppointmentEdit(int id)
        {
            MyDbContext db = new MyDbContext();
            var list = db.Appointmenties.Where(a => a.Id == id).FirstOrDefault();


            return View(list);
        }
        [HttpPost]
        public ActionResult AppointmentEdit(Appointments UpdateApp)
        {
            MyDbContext db = new MyDbContext();

            var update = db.Appointmenties.Where(a => a.Id == UpdateApp.Id).FirstOrDefault();
            update.Description = UpdateApp.Description;
            update.DateTimeStart = UpdateApp.DateTimeStart;
            db.SaveChanges();


            return RedirectToAction("AppointmentView");
        }


        public ActionResult AppointmentDel(int id)
        {
            MyDbContext db = new MyDbContext();
            var list = db.Appointments.Where(a => a.Id == id).FirstOrDefault();


            return View(list);
        }
        [HttpPost]
        public ActionResult AppointmentDel(Appointments DelApp)
        {
            MyDbContext db = new MyDbContext();


            try
            {

                Job DelOper = db.Appointments.Where(o => o.Id == DelApp.Id).FirstOrDefault();
                db.Appointments.Remove(DelOper);
                db.SaveChanges();
                return RedirectToAction("JobView");
            }
            catch
            {
                return View();
            }
        }


        rendevusistemi.Database.MyDbContext appointmentContext = new rendevusistemi.Database.MyDbContext();
        rendevusistemi.Database.MyDbContext resourceContext = new rendevusistemi.Database.MyDbContext();
        rendevusistemi.Database.MyDbContext jobs = new rendevusistemi.Database.MyDbContext();

        public ActionResult Scheduler1Partial()
        {
            var appointments = appointmentContext.Appointmenties;
            var resources = resourceContext.Employes;
            var aa = jobs.Jobs;

            ViewData["Appointments"] = appointments.ToList();
            ViewData["Resources"] = resources.ToList();
           

            return PartialView("_Scheduler1Partial");
        }
        public ActionResult Scheduler1PartialEditAppointment()
        {
            var appointments = appointmentContext.Appointmenties;
            var resources = resourceContext.Employes;

            try
            {
                AppointmentControllerScheduler1Settings.UpdateEditableDataObject(appointmentContext, resourceContext);
            }
            catch (Exception e)
            {
                ViewData["SchedulerErrorText"] = e.Message;
            }

            ViewData["Appointments"] = appointments.ToList();
            ViewData["Resources"] = resources.ToList();

            return PartialView("_Scheduler1Partial");
        }
    }
    public class AppointmentControllerScheduler1Settings
    {
        static DevExpress.Web.Mvc.MVCxAppointmentStorage appointmentStorage;
        public static DevExpress.Web.Mvc.MVCxAppointmentStorage AppointmentStorage
        {
            get
            {
                if (appointmentStorage == null)
                {
                    
                    appointmentStorage = new DevExpress.Web.Mvc.MVCxAppointmentStorage();
                    appointmentStorage.Mappings.AppointmentId = "Id";
                    appointmentStorage.Mappings.Start = "DateTimeStart";
                    appointmentStorage.Mappings.End = "DateTimeEnd";
                    appointmentStorage.Mappings.Subject = "Name";
                    appointmentStorage.Mappings.Description = "Description";
                    //appointmentStorage.Mappings.Location = "";
                    //appointmentStorage.Mappings.AllDay = "";
                    //appointmentStorage.Mappings.Type = "Id";
                    //appointmentStorage.Mappings.RecurrenceInfo = "";
                    //appointmentStorage.Mappings.ReminderInfo = "";
                    appointmentStorage.Mappings.Label = "JobId";
                    //appointmentStorage.Mappings.Status = "";
                    appointmentStorage.Mappings.ResourceId = "EmployeId";
                }
                return appointmentStorage;
            }
        }

        static DevExpress.Web.Mvc.MVCxResourceStorage resourceStorage;
        public static DevExpress.Web.Mvc.MVCxResourceStorage ResourceStorage
        {
            
            get
            {
                if (resourceStorage == null)
                {
                    resourceStorage = new DevExpress.Web.Mvc.MVCxResourceStorage();
                    resourceStorage.Mappings.ResourceId = "Id";
                    resourceStorage.Mappings.Caption = "Fullname";
                    
                }
                return resourceStorage;
            }
        }

        public static void UpdateEditableDataObject(rendevusistemi.Database.MyDbContext appointmentContext, rendevusistemi.Database.MyDbContext resourceContext)
        {
            InsertAppointments(appointmentContext, resourceContext);
            UpdateAppointments(appointmentContext, resourceContext);
            DeleteAppointments(appointmentContext, resourceContext);
        }

        static void InsertAppointments(rendevusistemi.Database.MyDbContext appointmentContext, rendevusistemi.Database.MyDbContext resourceContext)
        {
            var appointments = appointmentContext.Appointmenties.ToList();
            var resources = resourceContext.Employes.ToList();

            var newAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToInsert<rendevusistemi.Database.Data.Appointments>("Scheduler1", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in newAppointments)
            {
                appointmentContext.Appointmenties.Add(appointment);
            }
            appointmentContext.SaveChanges();
        }
        static void UpdateAppointments(rendevusistemi.Database.MyDbContext appointmentContext, rendevusistemi.Database.MyDbContext resourceContext)
        {
            var appointments = appointmentContext.Appointmenties.ToList();
            var resources = resourceContext.Employes;

            var updAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToUpdate<rendevusistemi.Database.Data.Appointments>("Scheduler1", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in updAppointments)
            {
                var origAppointment = appointments.FirstOrDefault(a => a.Id == appointment.Id);
                appointmentContext.Entry(origAppointment).CurrentValues.SetValues(appointment);
            }
            appointmentContext.SaveChanges();
        }

        static void DeleteAppointments(rendevusistemi.Database.MyDbContext appointmentContext, rendevusistemi.Database.MyDbContext resourceContext)
        {
            var appointments = appointmentContext.Appointmenties.ToList();
            var resources = resourceContext.Employes;

            var delAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToRemove<rendevusistemi.Database.Data.Appointments>("Scheduler1", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in delAppointments)
            {
                var delAppointment = appointments.FirstOrDefault(a => a.Id == appointment.Id);
                if (delAppointment != null)
                    appointmentContext.Appointmenties.Remove(delAppointment);
            }
            appointmentContext.SaveChanges();
        }


    }


}