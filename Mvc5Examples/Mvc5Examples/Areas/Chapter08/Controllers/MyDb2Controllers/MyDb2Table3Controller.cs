using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc5Examples.Areas.Chapter08.Models.MyDb2Model;

namespace Mvc5Examples.Areas.Chapter08.Controllers
{
    public class MyTable3Controller : Controller
    {
        private MyDb2 db = new MyDb2();

        // GET: Chapter08/MyTable3
        public ActionResult Index()
        {
            var myTable3 = db.MyTable3.Include(m => m.MyTable1).Include(m => m.MyTable2);
            return View(myTable3.ToList());
        }

        // GET: Chapter08/MyTable3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable3 myTable3 = db.MyTable3.Find(id);
            if (myTable3 == null)
            {
                return HttpNotFound();
            }
            return View(myTable3);
        }

        // GET: Chapter08/MyTable3/Create
        public ActionResult Create()
        {
            ViewBag.KeChengID = new SelectList(db.MyTable1, "KeChengID", "KeChengName");
            ViewBag.StudentID = new SelectList(db.MyTable2, "StudentID", "StudentName");
            return View();
        }

        // POST: Chapter08/MyTable3/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,KeChengID,Grade")] MyTable3 myTable3)
        {
            if (ModelState.IsValid)
            {
                db.MyTable3.Add(myTable3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KeChengID = new SelectList(db.MyTable1, "KeChengID", "KeChengName", myTable3.KeChengID);
            ViewBag.StudentID = new SelectList(db.MyTable2, "StudentID", "StudentName", myTable3.StudentID);
            return View(myTable3);
        }

        // GET: Chapter08/MyTable3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable3 myTable3 = db.MyTable3.Find(id);
            if (myTable3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.KeChengID = new SelectList(db.MyTable1, "KeChengID", "KeChengName", myTable3.KeChengID);
            ViewBag.StudentID = new SelectList(db.MyTable2, "StudentID", "StudentName", myTable3.StudentID);
            return View(myTable3);
        }

        // POST: Chapter08/MyTable3/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,KeChengID,Grade")] MyTable3 myTable3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myTable3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KeChengID = new SelectList(db.MyTable1, "KeChengID", "KeChengName", myTable3.KeChengID);
            ViewBag.StudentID = new SelectList(db.MyTable2, "StudentID", "StudentName", myTable3.StudentID);
            return View(myTable3);
        }

        // GET: Chapter08/MyTable3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable3 myTable3 = db.MyTable3.Find(id);
            if (myTable3 == null)
            {
                return HttpNotFound();
            }
            return View(myTable3);
        }

        // POST: Chapter08/MyTable3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyTable3 myTable3 = db.MyTable3.Find(id);
            db.MyTable3.Remove(myTable3);
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
