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
    public class MyDb2Table3Controller : Controller
    {
        private MyDb2 db = new MyDb2();

        // GET: Chapter08/MyTable3
        //public ActionResult Index()
        //{
        //    var myTable3 = db.MyTable3.Include(m => m.MyTable1).Include(m => m.MyTable2);
        //    return View(myTable3.ToList());
        //}
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                id = db.MyTable1.FirstOrDefault().KeChengID;
            }
            ViewBag.kcID = id;
            ViewBag.kcList = new SelectList(db.MyTable1, "KeChengID", "KeChengName", id);
            var list = GetMyTable3List(id);
            ViewBag.CanAdd = list.Count() > 0 ? false : true;
            if (Request.IsAjaxRequest())
            {
                return PartialView(list);
            }
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MyTable3 t)
        {
            var kcID = t.KeChengID;
            ViewBag.kcID = kcID;
            ViewBag.CanAdd = false;
            ViewBag.kcList = new SelectList(db.MyTable1, "KeChengID", "KeChengName", kcID);
            if (ModelState.IsValid)
            {
                string btn = Request["btn"];
                switch (btn)
                {
                    case "选择":
                        {
                            var t1 = GetMyTable3List(kcID);
                            ViewBag.CanAdd = t1.Count() > 0 ? false : true;
                            return PartialView(t1);
                        }
                    case "添加成绩":
                        {
                            try
                            {
                                foreach (var v in db.MyTable2)
                                {
                                    db.MyTable3.Add(new MyTable3 { StudentID = v.StudentID, KeChengID = kcID });
                                }
                                db.SaveChanges();
                            }
                            catch (DataException err)
                            {
                                ModelState.AddModelError("StudentID", "出错了。\n" + err.Message);
                            }
                            var t1 = GetMyTable3List(kcID);
                            return PartialView(t1);
                        }
                }
            }
            return PartialView();
        }

        private List<MyTable3> GetMyTable3List(string kcid)
        {
            var t = db.MyTable3
                .Include(m => m.MyTable2)
                .Include(m => m.MyTable1);
            if (string.IsNullOrEmpty(kcid) == false)
            {
                t = t.Where(x => x.KeChengID == kcid);
            }
            return t.OrderBy(m => m.StudentID).ToList();
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

        //// GET: Chapter08/MyTable3/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MyTable3 myTable3 = db.MyTable3.Find(id);
        //    if (myTable3 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.KeChengID = new SelectList(db.MyTable1, "KeChengID", "KeChengName", myTable3.KeChengID);
        //    ViewBag.StudentID = new SelectList(db.MyTable2, "StudentID", "StudentName", myTable3.StudentID);
        //    return View(myTable3);
        //}

        //// POST: Chapter08/MyTable3/Edit/5
        //// 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        //// 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,StudentID,KeChengID,Grade")] MyTable3 myTable3)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(myTable3).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.KeChengID = new SelectList(db.MyTable1, "KeChengID", "KeChengName", myTable3.KeChengID);
        //    ViewBag.StudentID = new SelectList(db.MyTable2, "StudentID", "StudentName", myTable3.StudentID);
        //    return View(myTable3);
        //}
        public ActionResult Edit(string kcid)
        {
            ViewBag.kcID = kcid;
            List<MyTable3> t = GetMyTable3List(kcid);
            return View(t);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(string kcID)
        {
            var t = GetMyTable3List(kcID);
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var v in t)
                    {
                        string k = "a" + v.ID;
                        v.Grade = int.Parse(Request[k]);
                        db.Entry(v).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                catch (DataException err)
                {
                    ModelState.AddModelError("StudentID", "出错了。\n" + err.Message);
                }
                return RedirectToAction("Index", new { id = kcID });
            }
            return View(t);
        }


        //// GET: Chapter08/MyTable3/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MyTable3 myTable3 = db.MyTable3.Find(id);
        //    if (myTable3 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(myTable3);
        //}

        //// POST: Chapter08/MyTable3/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    MyTable3 myTable3 = db.MyTable3.Find(id);
        //    db.MyTable3.Remove(myTable3);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string kcid)
        {
            var myTable3 = db.MyTable3.Where(x => x.KeChengID == kcid);
            foreach (var v in myTable3)
            {
                db.MyTable3.Remove(v);
            }
            db.SaveChanges();
            return RedirectToAction("Index", new { id = kcid });
        }

        public ActionResult GradeInfo(string search, string sortorder)
        {
            ViewBag.search = search;
            ViewBag.sortorder = sortorder;
            var t = db.MyTable3
                .Include(m => m.MyTable2)
                .Include(m => m.MyTable1)
                .OrderBy(m => m.StudentID)
                .ToList();
            if (string.IsNullOrEmpty(search)==false)
            {
                t = t.Where(m => m.MyTable2.StudentName.Contains(search) ||
                    m.MyTable1.KeChengName.Contains(search)).ToList();
            }
            if (string.IsNullOrEmpty(sortorder)==false)
            {
                switch (sortorder)
                {
                    case "StrudentID":
                        t = t.OrderBy(m => m.StudentID).ToList();
                        break;
                    case    "KeChengID":
                        t = t.OrderBy(m => m.KeChengID).ToList();
                        break;
                }
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView(t);
            }
            return View(t);
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
