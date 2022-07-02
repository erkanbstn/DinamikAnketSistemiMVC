using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TAnket
    {
        [Key]
        public int AnketID { get; set; }
        public string AnketAd { get; set; }
        public string AnketTip { get; set; }
        public int SirketID { get; set; }
        public virtual TSirket Sirket { get; set; }
        public List<TSoru> Soru { get; set; }

    }
}
