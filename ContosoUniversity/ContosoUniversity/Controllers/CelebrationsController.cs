using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.Models;
using PagedList;

namespace ContosoUniversity.Controllers
{
    public class CelebrationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Celebrations
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.currentSort = sortOrder;
            ViewBag.typeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.nameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            /*
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            */

            var usersCelebrations = db.Celebrations.Where(uc => uc.User.Email == User.Identity.Name).ToList();

            if(!String.IsNullOrEmpty(searchString))
            {
                usersCelebrations = usersCelebrations.Where(c => c.TypeOfCelebration.Contains(searchString)
                                    || c.Name.Contains(searchString)).ToList();
            } 
            switch(sortOrder)
            {
                case "type_desc":
                    usersCelebrations = usersCelebrations.OrderByDescending(c => c.TypeOfCelebration).ToList();
                        break;
                case "name":
                    usersCelebrations = usersCelebrations.OrderBy(c => c.Name).ToList();
                    break;
                case "name_desc":
                    usersCelebrations = usersCelebrations.OrderByDescending(c => c.Name).ToList();
                    break;
                case "Date":
                    usersCelebrations = usersCelebrations.OrderBy(c => c.CelebrationDate).ToList();
                    break;
                case "date_desc":
                    usersCelebrations = usersCelebrations.OrderByDescending(c => c.CelebrationDate).ToList();
                    break;
            }

            return View(usersCelebrations.ToList());
           // return View(db.Celebrations.ToList());
        }

        // GET: Celebrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             
            Celebration celebration = db.Celebrations.Find(id);
            if (celebration == null)
            {
                return HttpNotFound();
            }
            return View(celebration);
        }

        // GET: Celebrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Celebrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TypeOfCelebration,Name,CelebrationDate")] Celebration celebration)
        {
            if (ModelState.IsValid)
            {
                celebration.User = db.Users.First(u => u.Email == User.Identity.Name);
                db.Celebrations.Add(celebration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(celebration);
        }

        // GET: Celebrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celebration celebration = db.Celebrations.Find(id);
            if (celebration == null)
            {
                return HttpNotFound();
            }
            return View(celebration);
        }

        // POST: Celebrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TypeOfCelebration,Name,CelebrationDate")] Celebration celebration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(celebration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(celebration);
        }

        // GET: Celebrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celebration celebration = db.Celebrations.Find(id);
            if (celebration == null)
            {
                return HttpNotFound();
            }
            return View(celebration);
           
        }

        // POST: Celebrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Celebration celebration = db.Celebrations.Find(id);
            db.Celebrations.Remove(celebration);
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
