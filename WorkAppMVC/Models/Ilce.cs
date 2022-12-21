using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkAppMVC.Models
{
    public class Ilce
    {
        public int IlceId { get; set; }
        public string IlceAd { get; set; }
        public int SehirId { get; set; }
        public virtual Sehir Sehir { get; set; }
        public List<Mahalle> Mahalles { get; set; }

    }
}