﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proba.Models;

namespace Proba.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminSedniceController : Controller
    {
        private NNVEntities db = new NNVEntities();

        // GET: AdminSednice
        public ActionResult Index()
        {
            return View(db.Sednice.ToList());
        }

        // GET: AdminSednice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sednice sednice = db.Sednice.Find(id);
            if (sednice == null)
            {
                return HttpNotFound();
            }
            return View(sednice);
        }

        // GET: AdminSednice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminSednice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SednicaID,Datum,VrstaSednice,Ucionica,Zapisnik,Poziv")] Sednice sednice)
        {
            if (ModelState.IsValid)
            {
                db.Sednice.Add(sednice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sednice);
        }

        // GET: AdminSednice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sednice sednice = db.Sednice.Find(id);
            if (sednice == null)
            {
                return HttpNotFound();
            }
            return View(sednice);
        }

        // POST: AdminSednice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SednicaID,Datum,VrstaSednice,Ucionica,Zapisnik,Poziv")] Sednice sednice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sednice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sednice);
        }

        // GET: AdminSednice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sednice sednice = db.Sednice.Find(id);
            if (sednice == null)
            {
                return HttpNotFound();
            }
            return View(sednice);
        }

        // POST: AdminSednice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sednice sednice = db.Sednice.Find(id);
            db.Sednice.Remove(sednice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: AdminSednice/Prisustvo/5
        public ActionResult Prisustvo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Sednice sednice = db.Sednice.Find(id);
            //if (sednice == null)
            //{
            //    return HttpNotFound();
            //}
            var prisutni = db.Prisustvo.Include(s => s.Sednice).Where(s=>s.SednicaID==id);
            ViewBag.SednicaID = id.ToString();
            return View(prisutni);
        }

        // POST: AdminSednice/Prisustvo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Prisustvo([Bind(Include = "SednicaID,Datum,VrstaSednice,Ucionica,Zapisnik,Poziv")] Sednice sednice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sednice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sednice);
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