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
    public class EFPersonelDal : GenericRepository<TPersonel>, IPersonelDal
    {
        public List<TPersonel> SirketPersonelListe(int id)
        {
            using (var c = new Context())
            {
                return c.Personels.Where(n => n.SirketID == id).ToList();
            }
        }
        public TPersonel PersonelGiris(string kullanici, string sifre)
        {
            using (var c = new Context())
            {
                return c.Personels.FirstOrDefault(b => b.PersonelAd == kullanici && b.Sifre == sifre);
            }
        }

        public int ToplamPersonel(int id)
        {
            using (var c = new Context())
            {
                return c.Personels.Where(b => b.SirketID==id).Count();
            }
        }
    }
}
