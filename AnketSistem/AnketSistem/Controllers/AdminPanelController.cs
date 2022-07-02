using AnketSistem.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnketSistem.Controllers
{
    public class AdminPanelController : Controller
    {
        // ŞİRKET İŞLEMLERİ

        SirketManager sm = new SirketManager(new EFSirketDal());
        public ActionResult Sirketler()
        {
            return View(sm.GenelListele());
        }
        public ActionResult SirketEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SirketEkle(TSirket t)
        {
            // Otomatik Şifre Oluşumu

            t.Sifre = $"{t.Mudur.Substring(0, 2)}{DateTime.Now.Month}";
            sm.NesneEkle(t);
            return RedirectToAction("Sirketler");
        }
        public ActionResult SirketSil(int id)
        {
            sm.NesneSil(sm.NesneBul(id));
            return RedirectToAction("Sirketler");
        }
        public ActionResult SirketDuzenle(int id)
        {
            return View(sm.NesneBul(id));
        }
        [HttpPost]
        public ActionResult SirketDuzenle(TSirket t)
        {
            sm.NesneDuzenle(t);
            return RedirectToAction("Sirketler");
        }


        // PERSONEL İŞLEMLERİ 

        PersonelManager pm = new PersonelManager(new EFPersonelDal());
        public ActionResult Personeller()
        {
            return View(pm.GenelListele());
        }
        public ActionResult PersonelEkle()
        {
            ViewBag.sirket = sm.DropSirket();
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TPersonel t)
        {
            // Otomatik Şifre Oluşumu

            t.Sifre = $"{t.PersonelAd.Substring(0, 2)}{DateTime.Now.Month}";
            pm.NesneEkle(t);
            return RedirectToAction("Personeller");
        }
        public ActionResult PersonelSil(int id)
        {
            pm.NesneSil(pm.NesneBul(id));
            return RedirectToAction("Personeller");
        }
        public ActionResult PersonelDuzenle(int id)
        {
            ViewBag.sirket = sm.DropSirket();
            return View(pm.NesneBul(id));
        }
        [HttpPost]
        public ActionResult PersonelDuzenle(TPersonel t)
        {
            pm.NesneDuzenle(t);
            return RedirectToAction("Personeller");
        }


        // ANKET İŞLEMLERİ

        AnketManager am = new AnketManager(new EFAnketDal());
        public ActionResult Anketler()
        {
            return View(am.GenelListele());
        }
        public ActionResult AnketEkle()
        {
            ViewBag.sirket = sm.DropSirket();
            return View();
        }
        [HttpPost]
        public ActionResult AnketEkle(TAnket t)
        {
            am.NesneEkle(t);
            return RedirectToAction("Anketler");
        }
        public ActionResult AnketSil(int id)
        {
            am.NesneSil(am.NesneBul(id));
            return RedirectToAction("Anketler");
        }
        public ActionResult AnketDuzenle(int id)
        {
            ViewBag.sirket = sm.DropSirket();
            return View(am.NesneBul(id));
        }
        [HttpPost]
        public ActionResult AnketDuzenle(TAnket t)
        {
            am.NesneDuzenle(t);
            return RedirectToAction("Anketler");
        }

        // ANKET SORU İŞLEMLERİ

        SoruManager som = new SoruManager(new EFSoruDal());
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
            return View(cm.GenelListele());
        }
    }
}