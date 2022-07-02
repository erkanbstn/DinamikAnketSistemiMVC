using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _PersonelDal;
        public PersonelManager(IPersonelDal PersonelDal)
        {
            _PersonelDal = PersonelDal;
        }
        public List<TPersonel> GenelListele()
        {
            return _PersonelDal.TList();
        }

        public TPersonel NesneBul(int id)
        {
            return _PersonelDal.TGetID(b => b.PersonelID == id);
        }

        public void NesneDuzenle(TPersonel t)
        {
            _PersonelDal.TUpdate(t);
        }

        public void NesneEkle(TPersonel t)
        {
            _PersonelDal.TAdd(t);
        }

        public List<TPersonel> NesneListele(int id)
        {
            return _PersonelDal.TIDList(b => b.PersonelID == id);
        }

        public void NesneSil(TPersonel t)
        {
            _PersonelDal.TDelete(t);
        }

        public TPersonel PersonelGirisYap(string kullanici, string sifre)
        {
            return _PersonelDal.PersonelGiris(kullanici, sifre);
        }

        public List<TPersonel> SirketPersonelListele(int id)
        {
            return _PersonelDal.SirketPersonelListe(id);
        }

        public int ToplamSirketPersonel(int id)
        {
            return _PersonelDal.ToplamPersonel(id);
        }
    }
}
