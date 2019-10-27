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
    public class LocationSetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: LocationSets
        [Authorize]
        public ActionResult Index()
        {
            return View(db.LocationSets.ToList());
        }

        // GET: LocationSets/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationSet locationSet = db.LocationSets.Find(id);
            if (locationSet == null)
            {
                return HttpNotFound();
            }
            return View(locationSet);
        }

        // GET: LocationSets/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Latitude,Longitude")] LocationSet locationSet)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                if (userId == "02540576-eb9b-4583-bc4b-6c5f200a9118" || userId == "27f27b4d-9faf-4d02-b405-5592f9de1f08")
                {

                    db.LocationSets.Add(locationSet);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }

            return View(locationSet);
        }

        // GET: LocationSets/Edit/5
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationSet locationSet = db.LocationSets.Find(id);
            if (locationSet == null)
            {
                return HttpNotFound();
            }
            return View(locationSet);
        }

        // POST: LocationSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Latitude,Longitude")] LocationSet locationSet)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                if (userId == "02540576-eb9b-4583-bc4b-6c5f200a9118" || userId == "27f27b4d-9faf-4d02-b405-5592f9de1f08")

                {
                    db.Entry(locationSet).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(locationSet);
        }

        // GET: LocationSets/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationSet locationSet = db.LocationSets.Find(id);
            if (locationSet == null)
            {
                return HttpNotFound();
            }
            return View(locationSet);
        }

        // POST: LocationSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationSet locationSet = db.LocationSets.Find(id);
            var userId = User.Identity.GetUserId();
            if (userId == "02540576-eb9b-4583-bc4b-6c5f200a9118" || userId == "27f27b4d-9faf-4d02-b405-5592f9de1f08")

            {
                db.LocationSets.Remove(locationSet);
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
