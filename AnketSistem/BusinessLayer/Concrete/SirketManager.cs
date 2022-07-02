using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLayer.Concrete
{
    public class SirketManager : ISirketService
    {
        ISirketDal _sirketDal;
        public SirketManager(ISirketDal sirketDal)
        {
            _sirketDal = sirketDal;
        }
        public List<TSirket> GenelListele()
        {
            return _sirketDal.TList();
        }

        public TSirket NesneBul(int id)
        {
            return _sirketDal.TGetID(b => b.SirketID == id);
        }

        public void NesneDuzenle(TSirket t)
        {
            _sirketDal.TUpdate(t);
        }

        public void NesneEkle(TSirket t)
        {
            _sirketDal.TAdd(t);
        }

        public List<TSirket> NesneListele(int id)
        {
            return _sirketDal.TIDList(b => b.SirketID == id);
        }

        public void NesneSil(TSirket t)
        {
            _sirketDal.TDelete(t);
        }

        public List<SelectListItem> DropSirket()
        {
            return _sirketDal.PersonelSirketi();
        }

        public TSirket SirketGirisYap(string kullanici, string sifre)
        {
            return _sirketDal.SirketGiris(kullanici, sifre);
        }
    }
}
