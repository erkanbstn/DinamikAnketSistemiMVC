using AnketSistem.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnketSistem.Controllers
{
    public class SirketPanelController : Controller
    {
        PersonelManager pm = new PersonelManager(new EFPersonelDal());
        AnketManager am = new AnketManager(new EFAnketDal());
        SirketManager sm = new SirketManager(new EFSirketDal());
        SoruManager som = new SoruManager(new EFSoruDal());
        YorumManager ym = new YorumManager(new EFYorumDal());
        public ActionResult DashBoard()
        {
            int id = Convert.ToInt32(Session["SirketID"]);
            ViewBag.personel = pm.ToplamSirketPersonel(id);
            ViewBag.anket = am.ToplamSirketAnket(id);
            ViewBag.soru = som.ToplamSirketSoru(id);
            ViewBag.yorum = ym.ToplamSirketYorum(id);
            return View();
        }
        public ActionResult Anketler()
        {
            int id = Convert.ToInt32(Session["SirketID"]);
            return View(am.SirketAnketListele(id));
        }
        public ActionResult Personeller()
        {
            int id = Convert.ToInt32(Session["SirketID"]);
            return View(pm.SirketPersonelListele(id));
        }
        public ActionResult PersonelDuzenle(int id)
        {
            return View(pm.NesneBul(id));
        }
        [HttpPost]
        public ActionResult PersonelDuzenle(TPersonel t)
        {
            pm.NesneDuzenle(t);
            return RedirectToAction("Personeller");
        }
        public ActionResult AnketEkle()
        {
            int id = Convert.ToInt32(Session["SirketID"]);
            ViewBag.sirketid = id;
            return View();
        }
        [HttpPost]
        public ActionResult AnketEkle(TAnket t)
        {
            am.NesneEkle(t);
            return RedirectToAction("Anketler");
        }
        public ActionResult AnketSoruEkle(int id)
        {
            ViewBag.anket = id;
            return View();
        }
        [HttpPost]
        public ActionResult AnketSoruEkle(TSoru t)
        {
            som.NesneEkle(t);
            return RedirectToAction("Anketler");
        }
        public ActionResult AnketSoruGoruntule(int id)
        {
            Aktarim.AnketSoruID = id;
            return View(som.AnketSoruListele(id));
        }
        public ActionResult AnketDuzenle(int id)
        {
            int sirketid = Convert.ToInt32(Session["SirketID"]);
            ViewBag.sirketid = sirketid;
            return View(am.NesneBul(id));
        }
        [HttpPost]
        public ActionResult AnketDuzenle(TAnket t)
        {
            am.NesneDuzenle(t);
            return RedirectToAction("Anketler");
        }
        public ActionResult AnketSil(int id)
        {
            am.NesneSil(am.NesneBul(id));
            return RedirectToAction("Anketler");
        }
        public ActionResult SoruSil(int id)
        {
            som.NesneSil(som.NesneBul(id));
            return RedirectToAction("AnketSoruGoruntule", new { id = Aktarim.AnketSoruID });
        }
        public ActionResult SoruDuzenle(int id)
        {
            ViewBag.anket = Aktarim.AnketSoruID;
            return View(som.NesneBul(id));
        }
        [HttpPost]
        public ActionResult SoruDuzenle(TSoru t)
        {
            som.NesneDuzenle(t);
            return RedirectToAction("AnketSoruGoruntule", new { id = Aktarim.AnketSoruID });
        }
        CevapManager cm = new CevapManager(new EFCevapDal());
        public ActionResult SonucGoruntule(int id)
        {
            var x = am.NesneBul(id);
            ViewBag.anket = x.AnketID;
            ViewBag.anketad = x.AnketAd;
            ViewBag.sirket = x.SirketID;
            return View(cm.GenelListele());
        }
    }
}