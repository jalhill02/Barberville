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
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var service = CreateShopService();
            var model = service.GetShop();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopCreate model)
        {
            
            if (!ModelState.IsValid) return View(model);

            var service = CreateShopService();

            if (service.CreateShop(model))
            {
                TempData["SaveResult"] = "You have created a Shop.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Shop could not be created. ");

            return View(model);
        }

        private ShopService CreateShopService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShopService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateShopService();
            var model = svc.GetShopById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateShopService();
            var detail = service.GetShopById(id);
            var model =
                new ShopEdit
                {
                    ShopId = detail.ShopId,
                    ShopName = detail.ShopName,
                    ShopLocation = detail.ShopLocation,
                  
                };
            return View(model);
        }

        //Overload Method for Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShopEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            if (model.ShopId != id)

            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateShopService();

            if (service.EditShop(model))
            {
                TempData["SaveResult"] = "Your Shop was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Shop could not be updated.");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateShopService();
            var model = svc.GetShopById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateShopService();

            service.DeleteShop(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}