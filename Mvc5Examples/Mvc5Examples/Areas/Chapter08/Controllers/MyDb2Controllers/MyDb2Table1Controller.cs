﻿using System;
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
    public class MyDb2Table1Controller : Controller
    {
        private MyDb2 db = new MyDb2();

        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(db.MyTable1.ToList());
            }
            return View(db.MyTable1.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KeChengID,KeChengName")] MyTable1 myTable1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.MyTable1.Add(myTable1);
                    db.SaveChanges();
                }
                catch
                {
                    ModelState.AddModelError("KeChengID", "库中已存在该课程编号，不能重复添加。");
                    return View(myTable1);
                }
                return RedirectToAction("Index");
            }
            return View(myTable1);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable1 myTable1 = db.MyTable1.Find(id);
            if (myTable1 == null)
            {
                return HttpNotFound();
            }
            return View(myTable1);
        }

        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KeChengID,KeChengName")] MyTable1 myTable1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myTable1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myTable1);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable1 myTable1 = db.MyTable1.Find(id);
            if (myTable1 == null)
            {
                return HttpNotFound();
            }
            return View(myTable1);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MyTable1 myTable1 = db.MyTable1.Find(id);
            db.MyTable1.Remove(myTable1);
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
