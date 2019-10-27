using Microsoft.AspNet.Identity;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BookingSetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: BookingSets
        [Authorize]
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();
            var booking = db.BookingSets.Where(b => b.UserID == userId).ToList();
            if (userId == "02540576-eb9b-4583-bc4b-6c5f200a9118" || userId == "27f27b4d-9faf-4d02-b405-5592f9de1f08")
            {
                booking = db.BookingSets.ToList();
            }
          
            return View(booking);
        }

        // GET: BookingSets/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSet bookingSet = db.BookingSets.Find(id);
            if (bookingSet == null)
            {
                return HttpNotFound();
            }
            return View(bookingSet);
        }

        // GET: BookingSets/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.CarSets, "Id", "CarVin");
            ViewBag.LocationId = new SelectList(db.LocationSets, "Id", "Name");
            return View();
        }

        // POST: BookingSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "BookingID,BookingTime,RengtingStart,RentingEnd,Contact_PhonbeNumber,LocationId,CarId")] BookingSet bookingSet)
        {
            bookingSet.UserID = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(bookingSet);


            if (ModelState.IsValid)
            {
                db.BookingSets.Add(bookingSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.CarSets, "Id", "CarVin", bookingSet.CarId);
            ViewBag.LocationId = new SelectList(db.LocationSets, "Id", "Name", bookingSet.LocationId);
            return View(bookingSet);
        }

        // GET: BookingSets/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSet bookingSet = db.BookingSets.Find(id);
            if (bookingSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.CarSets, "Id", "CarVin", bookingSet.CarId);
            ViewBag.LocationId = new SelectList(db.LocationSets, "Id", "Name", bookingSet.LocationId);
            return View(bookingSet);
        }

        // POST: BookingSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit([Bind(Include = "BookingID,BookingTime,RengtingStart,RentingEnd,Contact_PhonbeNumber,LocationId,CarId,UserID")] BookingSet bookingSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.CarSets, "Id", "CarVin", bookingSet.CarId);
            ViewBag.LocationId = new SelectList(db.LocationSets, "Id", "Name", bookingSet.LocationId);
            return View(bookingSet);
        }

        // GET: BookingSets/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSet bookingSet = db.BookingSets.Find(id);
            if (bookingSet == null)
            {
                return HttpNotFound();
            }
            return View(bookingSet);
        }

        // POST: BookingSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingSet bookingSet = db.BookingSets.Find(id);
            db.BookingSets.Remove(bookingSet);
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
