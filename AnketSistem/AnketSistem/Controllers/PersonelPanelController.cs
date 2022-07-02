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
    public class PersonelPanelController : Controller
    {
        AnketManager am = new AnketManager(new EFAnketDal());
        PersonelManager pm = new PersonelManager(new EFPersonelDal());
        SoruManager sm = new SoruManager(new EFSoruDal());
        CevapManager cm = new CevapManager(new EFCevapDal());
        YorumManager ym = new YorumManager(new EFYorumDal());
        public ActionResult Anketler()
        {
            int id = Convert.ToInt32(Session["PersonelID"]);
            var sirket = pm.NesneBul(id);
            return View(am.SirketAnketListele(sirket.PersonelID));
        }
        public ActionResult AnketCevapla(int id)
        {
            var anket = am.NesneBul(id);
            ViewBag.anket = anket.AnketAd;
            return View(sm.AnketSoruListele(id));
        }
        [HttpPost]
        public ActionResult AnketCevapla(TYorum y,TCevap t,string[] cevap,int[] soru)
        {
            int pid = Convert.ToInt32(Session["PersonelID"]);
            for (int i = 0; i < cevap.Length; i++)
            {
                t.PersonelID = pid;
                t.CevapAd = cevap[i];
                t.SoruID = soru[i];
                cm.NesneEkle(t);
            }
            y.PersonelID = pid;
            ym.NesneEkle(y);
            return RedirectToAction("Anketler");
        }

        public ActionResult Profilim()
        {
            int pid = Convert.ToInt32(Session["PersonelID"]);
            return View(pm.NesneBul(pid));
        }
        [HttpPost]
        public ActionResult Profilim(TPersonel t)
        {
            int pid = Convert.ToInt32(Session["PersonelID"]);
            pm.NesneDuzenle(t);
            return View(pm.NesneBul(pid));
        }
    }
}