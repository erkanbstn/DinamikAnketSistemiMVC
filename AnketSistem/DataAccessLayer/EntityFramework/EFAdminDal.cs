using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFAdminDal : GenericRepository<TAdmin>, IAdminDal
    {
        public TAdmin AdminGiris(string kullanici, string sifre)
        {
            using (var c = new Context())
            {
                return c.Admins.FirstOrDefault(b => b.KullaniciAd == kullanici && b.Sifre == sifre);
            }
        }
    }
}
