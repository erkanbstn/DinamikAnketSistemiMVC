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
    public class EFCevapDal : GenericRepository<TCevap>, ICevapDal
    {
        public List<TCevap> SoruCevapListe(int id)
        {
            using (var c = new Context())
            {
                return c.Cevaps.Where(n=>n.SoruID==id).ToList();
            }
        }
    }
}
