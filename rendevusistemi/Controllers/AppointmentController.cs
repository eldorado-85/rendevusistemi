using DevExpress.Web.Mvc;
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



        rendevusistemi.Database.MyDbContext appointmentContext = new rendevusistemi.Database.MyDbContext();
        rendevusistemi.Database.MyDbContext resourceContext = new rendevusistemi.Database.MyDbContext();

        public ActionResult Scheduler1Partial()
        {
            var appointments = appointmentContext.Appointmenties;
            var resources = resourceContext.Employes;

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
                    appointmentStorage.Mappings.Location = "";
                    appointmentStorage.Mappings.AllDay = "";
                    appointmentStorage.Mappings.Type = "Id";
                    appointmentStorage.Mappings.RecurrenceInfo = "";
                    appointmentStorage.Mappings.ReminderInfo = "";
                    appointmentStorage.Mappings.Label = "Id";
                    appointmentStorage.Mappings.Status = "";
                    appointmentStorage.Mappings.ResourceId = "Emloiess";
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
                    resourceStorage.Mappings.Caption = "Firstname";
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
            var resources = resourceContext.Employes;

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