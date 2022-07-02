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
    public class EFSoruDal : GenericRepository<TSoru>, ISoruDal
    {
        public List<TSoru> AnketSoruListe(int id)
        {
            using(var c = new Context())
            {
                return c.Sorus.Where(b => b.AnketID == id).ToList();
            }
        }
        public int ToplamSoru(int id)
        {
            using (var c = new Context())
            {
                return c.Sorus.Where(b => b.Anket.SirketID == id).Count();
            }
        }
    }
}
