using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccessLayer.EntityFramework
{
    public class EFSirketDal : GenericRepository<TSirket>, ISirketDal
    {
        public List<SelectListItem> PersonelSirketi()
        {
            using (var c = new Context())
            {
                return (from v in c.Sirkets.ToList() select new SelectListItem { Text = v.SirketAd, Value = v.SirketID.ToString() }).ToList();
            }
        }
        public TSirket SirketGiris(string kullanici, string sifre)
        {
            using (var c = new Context())
            {
                return c.Sirkets.FirstOrDefault(b => b.Mudur == kullanici && b.Sifre == sifre);
            }
        }
    }
}
