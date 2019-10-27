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
    public class OrderLineSetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: OrderLineSets
        [Authorize]
        public ActionResult Index()
        {
            var orderLineSets = db.OrderLineSets.Include(o => o.BookingSet);
            return View(orderLineSets.ToList());
        }

        // GET: OrderLineSets/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLineSet orderLineSet = db.OrderLineSets.Find(id);
            if (orderLineSet == null)
            {
                return HttpNotFound();
            }
            return View(orderLineSet);
        }

        // GET: OrderLineSets/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.BookingBookingID1 = new SelectList(db.BookingSets, "BookingID", "Contact_PhonbeNumber");
            return View();
        }

        // POST: OrderLineSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,ConfirmStartTime,ConfirmEndTime,ReturnStatus,BookingBookingID1")] OrderLineSet orderLineSet)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                if (userId == "02540576-eb9b-4583-bc4b-6c5f200a9118" || userId == "27f27b4d-9faf-4d02-b405-5592f9de1f08")

                {
                    db.OrderLineSets.Add(orderLineSet);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.BookingBookingID1 = new SelectList(db.BookingSets, "BookingID", "Contact_PhonbeNumber", orderLineSet.BookingBookingID1);
            return View(orderLineSet);
        }

        // GET: OrderLineSets/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLineSet orderLineSet = db.OrderLineSets.Find(id);
            if (orderLineSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingBookingID1 = new SelectList(db.BookingSets, "BookingID", "Contact_PhonbeNumber", orderLineSet.BookingBookingID1);
            return View(orderLineSet);
        }

        // POST: OrderLineSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,ConfirmStartTime,ConfirmEndTime,ReturnStatus,BookingBookingID1")] OrderLineSet orderLineSet)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                if (userId == "02540576-eb9b-4583-bc4b-6c5f200a9118" || userId == "27f27b4d-9faf-4d02-b405-5592f9de1f08")

                {
                    db.Entry(orderLineSet).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.BookingBookingID1 = new SelectList(db.BookingSets, "BookingID", "Contact_PhonbeNumber", orderLineSet.BookingBookingID1);
            return View(orderLineSet);
        }

        // GET: OrderLineSets/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLineSet orderLineSet = db.OrderLineSets.Find(id);
            if (orderLineSet == null)
            {
                return HttpNotFound();
            }
            return View(orderLineSet);
        }

        // POST: OrderLineSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderLineSet orderLineSet = db.OrderLineSets.Find(id);
            var userId = User.Identity.GetUserId();
            if (userId == "02540576-eb9b-4583-bc4b-6c5f200a9118" || userId == "27f27b4d-9faf-4d02-b405-5592f9de1f08")

            {
                db.OrderLineSets.Remove(orderLineSet);
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
