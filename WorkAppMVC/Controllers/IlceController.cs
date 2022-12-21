using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkAppMVC.Models;

namespace WorkAppMVC.Controllers
{
    public class IlceController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Ilce
        public ActionResult Index()
        {
            var ilces = db.Ilces.Include(i => i.Sehir);
            return View(ilces.ToList());
        }

        // GET: Ilce/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilces.Find(id);
            
            if    (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        // GET: Ilce/Create
        public ActionResult Create()
        {
            ViewBag.SehirId = new SelectList(db.Sehirs, "SehirId", "SehirAd");
            return View();
        }

        // POST: Ilce/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IlceId,IlceAd,SehirId")] Ilce ilce)
        {
            if (ModelState.IsValid)
            {
                db.Ilces.Add(ilce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SehirId = new SelectList(db.Sehirs, "SehirId", "SehirAd", ilce.SehirId);
            return View(ilce);
        }

        // GET: Ilce/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilces.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            ViewBag.SehirId = new SelectList(db.Sehirs, "SehirId", "SehirAd", ilce.SehirId);
            return View(ilce);
        }

        // POST: Ilce/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IlceId,IlceAd,SehirId")] Ilce ilce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SehirId = new SelectList(db.Sehirs, "SehirId", "SehirAd", ilce.SehirId);
            return View(ilce);
        }

        // GET: Ilce/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilces.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        // POST: Ilce/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilce ilce = db.Ilces.Find(id);
            db.Ilces.Remove(ilce);
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
