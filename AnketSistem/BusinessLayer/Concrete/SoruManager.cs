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
    public class SoruManager : ISoruService
    {
        ISoruDal _SoruDal;
        public SoruManager(ISoruDal SoruDal)
        {
            _SoruDal = SoruDal;
        }

        public List<TSoru> AnketSoruListele(int id)
        {
            return _SoruDal.AnketSoruListe(id);
        }

        public List<TSoru> GenelListele()
        {
            return _SoruDal.TList();
        }

        public TSoru NesneBul(int id)
        {
            return _SoruDal.TGetID(b => b.SoruID == id);
        }

        public void NesneDuzenle(TSoru t)
        {
            _SoruDal.TUpdate(t);
        }

        public void NesneEkle(TSoru t)
        {
            _SoruDal.TAdd(t);
        }

        public List<TSoru> NesneListele(int id)
        {
            return _SoruDal.TIDList(b => b.SoruID == id);
        }

        public void NesneSil(TSoru t)
        {
            _SoruDal.TDelete(t);
        }

        public int ToplamSirketSoru(int id)
        {
            return _SoruDal.ToplamSoru(id);
        }
    }
}
