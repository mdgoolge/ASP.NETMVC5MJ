using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc5My.Areas.Chapter08.Models.MyDb2Model;

namespace Mvc5My.Areas.Chapter08.Controllers.MyDb2Controllers
{
    public class MyDb2Table2Controller : Controller
    {
        private MyDb2 db = new MyDb2();

        // GET: Chapter08/MyTable2
        public ActionResult Index()
        {
            //return View(db.MyTable2.ToList());
            if (Request.IsAjaxRequest())
            {
                return PartialView(db.MyTable2.ToList());
            }
            return View(db.MyTable2.ToList());
        }

        // GET: Chapter08/MyTable2/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable2 myTable2 = db.MyTable2.Find(id);
            if (myTable2 == null)
            {
                return HttpNotFound();
            }
            return View(myTable2);
        }

        // GET: Chapter08/MyTable2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chapter08/MyTable2/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,StudentName,RuXueShiJian")] MyTable2 myTable2)
        {
            if (ModelState.IsValid)
            {
                db.MyTable2.Add(myTable2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myTable2);
        }

        // GET: Chapter08/MyTable2/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable2 myTable2 = db.MyTable2.Find(id);
            if (myTable2 == null)
            {
                return HttpNotFound();
            }
            return View(myTable2);
        }

        // POST: Chapter08/MyTable2/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,StudentName,RuXueShiJian")] MyTable2 myTable2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myTable2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myTable2);
        }

        // GET: Chapter08/MyTable2/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable2 myTable2 = db.MyTable2.Find(id);
            if (myTable2 == null)
            {
                return HttpNotFound();
            }
            return View(myTable2);
        }

        // POST: Chapter08/MyTable2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MyTable2 myTable2 = db.MyTable2.Find(id);
            db.MyTable2.Remove(myTable2);
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
