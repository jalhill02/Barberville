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
    public class BarberController : Controller
    {
        // GET: Barber
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BarberService((userId));
            var model = service.GetBarbers();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BarberCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBarberService();

            if (service.CreateBarber(model))
            {
                TempData["SaveResult"] = "You have created a Barber.";
                return RedirectToAction("Index");    
            };

            ModelState.AddModelError("", "Barber could not be created. ");

            return View(model);
        }

        private BarberService CreateBarberService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BarberService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBarberService();
            var model = svc.GetBarberById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBarberService();
            var detail = service.GetBarberById(id);
            var model =
                new BarberEdit
                {
                    BarberId = detail.BarberId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    ShopName = detail.ShopName,
                    ShopLocation = detail.ShopLocation
                };
            return View(model);
        }

        //Overload Method for Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BarberEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            if (model.ShopId != id)

            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBarberService();

            if (service.EditBarber(model))
            {
                TempData["SaveResult"] = "Your Barber was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Barber could not be updated.");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBarberService();
            var model = svc.GetBarberById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBarberService();

            service.DeleteBarber(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}