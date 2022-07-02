using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AnketSistem.Controllers
{
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager(new EFAdminDal());
        SirketManager sm = new SirketManager(new EFSirketDal());
        PersonelManager pm = new PersonelManager(new EFPersonelDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(TAdmin t)
        {
            var bilgi = am.AdminGirisYap(t.KullaniciAd, t.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAd, false);
                Session["Role"] = "Admin";
                return RedirectToAction("Sirketler", "AdminPanel");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SirketLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SirketLogin(TSirket t)
        {
            var bilgi = sm.SirketGirisYap(t.Mudur, t.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Mudur, false);
                Session["Role"] = "Mudur";
                Session["SirketID"] = bilgi.SirketID;
                return RedirectToAction("Anketler", "SirketPanel");
            }
            else
            {
                return View();
            }
        }
        public ActionResult PersonelLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelLogin(TPersonel t)
        {
            var bilgi = pm.PersonelGirisYap(t.PersonelAd, t.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.PersonelAd, false);
                Session["Role"] = "Personel";
                Session["PersonelID"] = bilgi.PersonelID;
                return RedirectToAction("Anketler", "PersonelPanel");
            }
            else
            {
                return View();
            }
            return View();
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}