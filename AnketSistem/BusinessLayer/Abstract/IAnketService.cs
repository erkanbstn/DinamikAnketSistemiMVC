using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAnketService : IGenericService<TAnket>
    {
        List<TAnket> SirketAnketListele(int id);
        int ToplamSirketAnket(int id);
    }
}
