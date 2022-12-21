using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkAppMVC.Models
{
    public class Mahalle
    {
        public int MahalleId { get; set; }
        public string MahalleAd { get; set; }
        public int IlceId { get; set; }
        public virtual Ilce Ilce { get; set; }
    }
}