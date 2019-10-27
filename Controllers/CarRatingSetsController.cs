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
    public class CarRatingSetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: CarRatingSets
        [Authorize]
        public ActionResult Index()
        {
            var carRatingSets = db.CarRatingSets.Include(c => c.CarSet);
            return View(carRatingSets.ToList());
        }

        // GET: CarRatingSets/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRatingSet carRatingSet = db.CarRatingSets.Find(id);
            if (carRatingSet == null)
            {
                return HttpNotFound();
            }
            return View(carRatingSet);
        }

        // GET: CarRatingSets/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.CarSets, "Id", "CarVin");
            return View();
        }

        // POST: CarRatingSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,CarId,Rating,Comment")] CarRatingSet carRatingSet)
        {
            if (ModelState.IsValid)
            {
                db.CarRatingSets.Add(carRatingSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.CarSets, "Id", "CarVin", carRatingSet.CarId);
            return View(carRatingSet);
        }

        // GET: CarRatingSets/Edit/5

        [Authorize]
        [ValidateInput(false)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRatingSet carRatingSet = db.CarRatingSets.Find(id);
            if (carRatingSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.CarSets, "Id", "CarVin", carRatingSet.CarId);
            return View(carRatingSet);
        }

        // POST: CarRatingSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ValidateInput(false)]

        public ActionResult Edit([Bind(Include = "Id,CarId,Rating,Comment")] CarRatingSet carRatingSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carRatingSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.CarSets, "Id", "CarVin", carRatingSet.CarId);
            return View(carRatingSet);
        }

        // GET: CarRatingSets/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRatingSet carRatingSet = db.CarRatingSets.Find(id);
            if (carRatingSet == null)
            {
                return HttpNotFound();
            }
            return View(carRatingSet);
        }

        // POST: CarRatingSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            CarRatingSet carRatingSet = db.CarRatingSets.Find(id);
            db.CarRatingSets.Remove(carRatingSet);
            db.SaveChanges();
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
