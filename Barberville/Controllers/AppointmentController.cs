using Barbervill.Models;
using Barberville.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberville.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment

        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AppointmentService((userId));
            var model = service.GetAppointments();

            return View(model);
        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAppointmentService();

            if (service.CreateAppointment(model))
            {
                TempData["SaveResult"] = "You have created a appointment.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "appointment could not be created. ");

            return View(model);
        }

        private AppointmentService CreateAppointmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AppointmentService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAppointmentService();
            var model = svc.GetAppointmentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAppointmentService();
            var detail = service.GetAppointmentById(id);
            var model =
                new AppointmentEdit
                {
                 AppointmentId = detail.AppointmentId,
                  Services = detail.services,
                  //BarberId = detail.BarberId,
                 // CustomerId = detail.BarberId,
                 DateTime = detail.DateTime

                };
            return View(model);
        }

        //Overload Method for Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AppointmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            if (model.AppointmentId != id)

            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAppointmentService();

            if (service.EditAppointment(model))
            {
                TempData["SaveResult"] = "Your Appointment was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Appointment could not be updated.");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAppointmentService();
            var model = svc.GetAppointmentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAppointmentService();

            service.DeleteAppointment(id);

            TempData["SaveResult"] = "Your appointment was deleted";

            return RedirectToAction("Index");
        }
    }
}