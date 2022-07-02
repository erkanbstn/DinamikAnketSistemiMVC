using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPersonelDal : IRepositoryDal<TPersonel>
    {
        List<TPersonel> SirketPersonelListe(int id);
        int ToplamPersonel(int id);
        TPersonel PersonelGiris(string kullanici, string sifre);

    }
}
