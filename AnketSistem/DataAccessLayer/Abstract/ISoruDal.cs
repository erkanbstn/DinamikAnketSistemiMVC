using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISoruDal : IRepositoryDal<TSoru>
    {
        List<TSoru> AnketSoruListe(int id);
        int ToplamSoru(int id);
    }
}
