using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkAppMVC.Models;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace WorkAppMVC.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index(int sayi=1)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;

            var ilan = db.Ilans.Include(m => m.Mahalle).Include(e => e.Mekan);
            return View(ilan.ToList().ToPagedList(sayi,3));
        }

        public ActionResult DurumList(int id)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var ilan = db.Ilans.Where(i=>i.DurumId==id).Include(m => m.Mahalle).Include(e => e.Mekan);
            return View(ilan.ToList());
        }

        public ActionResult MenuFiltre(int id)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var filtre= db.Ilans.Where(i=>i.MekanId==id).Include(m => m.Mahalle).Include(e => e.Mekan).ToList();
            return View(filtre);
        }

        public PartialViewResult PartialFiltre()
        {
            ViewBag.sehirlist = new SelectList(ŞehirGetir(), "SehirId", "SehirAd");
            ViewBag.durumlist = new SelectList(DurumGetir(), "DurumId", "DurumAd");
            return PartialView();
        }

        public ActionResult Filtre(int min, int max, int sehirid, int mahalleid, int ilceid, int durumid, int mekanid)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;

            var filtre = db.Ilans.Where(i => i.Ücret >= min && i.Ücret <= max
             && i.DurumId == durumid
             && i.IlceId == ilceid
             && i.MahalleId == mahalleid
             && i.SehirId == sehirid
             && i.MekanId == mekanid).Include(m => m.Mahalle).Include(e => e.Mekan).ToList();
            return View(filtre);
        }

        public List<Sehir> ŞehirGetir()
        {
            List<Sehir> sehirler = db.Sehirs.ToList();
            return sehirler;
        }

        public ActionResult IlceGetir(int SehirId)
        {
            List<Ilce> ilcelist = db.Ilces.Where(x => x.SehirId == SehirId).ToList();
            ViewBag.ilcelistesi = new SelectList(ilcelist, "IlceId", "IlceAd");
            return PartialView("IlcePartial");
        }

        public ActionResult MahalleGetir(int IlceId)
        {
            List<Mahalle> mahallelist = db.Mahalles.Where(x => x.IlceId == IlceId).ToList();
            ViewBag.mahallelistesi = new SelectList(mahallelist, "MahalleId", "MahalleAd");
            return PartialView("MahallePartial");
        }

        public List<Durum> DurumGetir()
        {
            List<Durum> durumlar = db.Durums.ToList();
            return durumlar;
        }

        public ActionResult MekanGetir(int DurumId)
        {
            List<Mekan> mekanlist = db.Mekans.Where(x => x.DurumId == DurumId).ToList();
            ViewBag.mekanlistesi = new SelectList(mekanlist, "MekanId", "MekanAd");
            return PartialView("MekanPartial");
        }

        public ActionResult Search(string q)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var ara = db.Ilans.Include(m => m.Mahalle).Include(e => e.Mekan);
            if (!string.IsNullOrEmpty(q))
            {
                ara = ara.Where(i => i.Açıklama.Contains(q) || i.Mahalle.MahalleAd.Contains(q) || i.Mekan.MekanAd.Contains(q));

            }
            return View(ara.ToList());
        }

        public ActionResult Detay(int id)
        {
            var ilan = db.Ilans.Where(i => i.IlanId == id).Include(m => m.Mahalle).Include(e => e.Mekan).FirstOrDefault();
            var imgs = db.Resims.Where(i => i.IlanId == id).ToList();
            ViewBag.imgs = imgs;
            return View(ilan);
        }
        public PartialViewResult Slider()
        {
            var ilan = db.Ilans.ToList().Take(5);
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            return PartialView(ilan);
        }
    }

}