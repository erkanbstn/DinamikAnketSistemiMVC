using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TSirket
    {
        [Key]
        public int SirketID { get; set; }
        public string SirketAd { get; set; }
        public string Mudur { get; set; }
        public string Sifre { get; set; }
        public ICollection<TPersonel> Personel { get; set; }
        public ICollection<TAnket> Anket { get; set; }

    }
}
