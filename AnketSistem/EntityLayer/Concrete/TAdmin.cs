using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TAdmin
    {
        [Key]
        public int AdminID { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
    }
}
