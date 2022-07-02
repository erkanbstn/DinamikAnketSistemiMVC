using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TPersonel
    {
        [Key]
        public int PersonelID { get; set; }
        public string PersonelAd { get; set; }
        public string Sifre { get; set; }
        public int SirketID { get; set; }
        public virtual TSirket Sirket { get; set; }
        public ICollection<TCevap> Cevap { get; set; }
        public ICollection<TYorum> Yorum { get; set; }
    }
}
