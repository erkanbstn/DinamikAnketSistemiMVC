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
    public class EFAnketDal : GenericRepository<TAnket>, IAnketDal
    {
        public List<TAnket> SirketAnketListe(int id)
        {
            using (var c = new Context())
            {
                return c.Ankets.Where(n => n.SirketID == id).ToList();
            }
        }
        public int ToplamAnket(int id)
        {
            using (var c = new Context())
            {
                return c.Ankets.Where(b => b.SirketID == id).Count();
            }
        }
    }
}
