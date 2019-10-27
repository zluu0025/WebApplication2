using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CarSetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: CarSets
        [Authorize]
        public ActionResult Index()
        {
            return View(db.CarSets.ToList());
        }

        // GET: CarSets/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSet carSet = db.CarSets.Find(id);
            if (carSet == null)
            {
                return HttpNotFound();
            }
            return View(carSet);
        }

        // GET: CarSets/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ValidateInput(false)]

        public ActionResult Create([Bind(Include = "Id,CarVin,CarMark,CarModel,CarType,CarPrice,CarRegisterDate")] CarSet carSet)
        {

            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                if (userId == "02540576-eb9b-4583-bc4b-6c5f200a9118" || userId == "27f27b4d-9faf-4d02-b405-5592f9de1f08")
                {
                    db.CarSets.Add(carSet);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(carSet);
        }

        // GET: CarSets/Edit/5
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSet carSet = db.CarSets.Find(id);
            if (carSet == null)
            {
                return HttpNotFound();
            }
            return View(carSet);
        }

        // POST: CarSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,CarVin,CarMark,CarModel,CarType,CarPrice,CarRegisterDate")] CarSet carSet)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                if (userId == "02540576-eb9b-4583-bc4b-6c5f200a9118" || userId == "27f27b4d-9faf-4d02-b405-5592f9de1f08")
                {
                    db.Entry(carSet).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(carSet);
        }

        // GET: CarSets/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSet carSet = db.CarSets.Find(id);
            if (carSet == null)
            {
                return HttpNotFound();
            }
            return View(carSet);
        }

        // POST: CarSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            CarSet carSet = db.CarSets.Find(id);
            var userId = User.Identity.GetUserId();
            if (userId == "02540576-eb9b-4583-bc4b-6c5f200a9118" || userId == "27f27b4d-9faf-4d02-b405-5592f9de1f08")

            {
                db.CarSets.Remove(carSet);
                db.SaveChanges();             
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
