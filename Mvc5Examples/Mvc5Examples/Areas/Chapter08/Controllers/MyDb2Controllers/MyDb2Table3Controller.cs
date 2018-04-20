using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc5Examples.Areas.Chapter08.Models.MyDb2Model;

namespace Mvc5Examples.Areas.Chapter08.Controllers.MyDb2Controllers
{
    public class MyDb2Table3Controller : Controller
    {
        private MyDb2 db = new MyDb2();

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

        public ActionResult GradeInfo(string search, string sortOrder)
        {
            ViewBag.search = search;
            ViewBag.sortOrder = sortOrder;
            var t = db.MyTable3
                .Include(m => m.MyTable2)
                .Include(m => m.MyTable1)
                .OrderBy(m => m.StudentID)
                .ToList();
            if (string.IsNullOrEmpty(search) == false)
            {
                t = t.Where(m => m.MyTable2.StudentName.Contains(search) ||
                    m.MyTable1.KeChengName.Contains(search)).ToList();
            }
            if (string.IsNullOrEmpty(sortOrder) == false)
            {
                switch (sortOrder)
                {
                    case "StudentID":
                        t = t.OrderBy(m => m.StudentID).ToList();
                        break;
                    case "KeChengID":
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
