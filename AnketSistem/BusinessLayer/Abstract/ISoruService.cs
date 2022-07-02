using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISoruService : IGenericService<TSoru>
    {
        List<TSoru> AnketSoruListele(int id);
        int ToplamSirketSoru(int id);
    }
}
