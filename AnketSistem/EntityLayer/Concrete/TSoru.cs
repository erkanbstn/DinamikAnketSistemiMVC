using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TSoru
    {
        [Key]
        public int SoruID { get; set; }
        public string SoruAd { get; set; }
        public int? AnketID { get; set; }
        public virtual TAnket Anket { get; set; }
        public List<TCevap> Cevap { get; set; }
    }
}
