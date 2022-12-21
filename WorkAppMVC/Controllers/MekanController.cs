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
    public class MekanController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Mekan
        public ActionResult Index()
        {
            var mekans = db.Mekans.Include(m => m.Durum);
            return View(mekans.ToList());
        }

        public PartialViewResult DurumAd1()
        {
            var durumad1 = db.Mekans.Where(i => i.DurumId == 1).FirstOrDefault();
            return PartialView(durumad1);
        }

        public PartialViewResult DurumAd2()
        {
            var durumad2 = db.Mekans.Where(i => i.DurumId == 2).FirstOrDefault();
            return PartialView(durumad2);
        }

        public PartialViewResult DurumTip1()
        {
            var durumtip1 = db.Mekans.Where(i => i.DurumId == 1).ToList();
            return PartialView(durumtip1);
        }

        public PartialViewResult DurumTip2()
        {
            var durumtip2 = db.Mekans.Where(i => i.DurumId == 2).ToList();
            return PartialView(durumtip2);
        }

        // GET: Mekan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mekan mekan = db.Mekans.Find(id);
            if (mekan == null)
            {
                return HttpNotFound();
            }
            return View(mekan);
        }

        // GET: Mekan/Create
        public ActionResult Create()
        {
            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd");
            return View();
        }

        // POST: Mekan/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MekanId,MekanAd,DurumId")] Mekan mekan)
        {
            if (ModelState.IsValid)
            {
                db.Mekans.Add(mekan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd", mekan.DurumId);
            return View(mekan);
        }

        // GET: Mekan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mekan mekan = db.Mekans.Find(id);
            if (mekan == null)
            {
                return HttpNotFound();
            }
            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd", mekan.DurumId);
            return View(mekan);
        }

        // POST: Mekan/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MekanId,MekanAd,DurumId")] Mekan mekan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mekan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd", mekan.DurumId);
            return View(mekan);
        }

        // GET: Mekan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mekan mekan = db.Mekans.Find(id);
            if (mekan == null)
            {
                return HttpNotFound();
            }
            return View(mekan);
        }

        // POST: Mekan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mekan mekan = db.Mekans.Find(id);
            db.Mekans.Remove(mekan);
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
