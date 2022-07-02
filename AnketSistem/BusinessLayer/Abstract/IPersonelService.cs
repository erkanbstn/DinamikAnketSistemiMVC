using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPersonelService:IGenericService<TPersonel>
    {
        List<TPersonel> SirketPersonelListele(int id);
        int ToplamSirketPersonel(int id);
        TPersonel PersonelGirisYap(string kullanici, string sifre);

    }

}
